using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Xie_Core
{
    public static class ObjectExtension
    {

        public static T SafeJsonObject<T>(this string str)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception ex)
            {
                //AtawTrace.WriteStringFile("JsonConvert", ex.Message);
                return default(T);
            }
        }

        public static string ToJson<T>(this T obj)
        {
            return ToJSON(obj);
        }
        private static string ToJSON(object oo)
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();

            var iso = new IsoDateTimeConverter();
            iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            setting.Converters = new List<JsonConverter> { new StringEnumConverter(), iso };
            setting.Formatting = Formatting.Indented;
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // setting.en
            return JsonConvert.SerializeObject(oo, setting);
        }
        public static T AppKv<T>(this string regName, T def)
        {
            T result = default(T);
            if (def != null)
            {
                result = def;
            }
            //var _obj = .AppSettings[regName];
            //if (_obj != null)
            //{
            //    try
            //    {
            //        string _exeStr = _obj.ForceExeValue() ?? _obj.Value;
            //        return _exeStr.Value<T>(def);
            //    }
            //    catch (Exception ex)
            //    {
            //        //AtawTrace.WriteFile(LogType.AppKvError,
            //        //    "注册表达式为{0}的弘插件在Key为{1}的配置执行上发生错误{2}{3}".AkFormat(_obj.Value, regName, Environment.NewLine, ex.Message + ex.StackTrace));
            //        result = def;
            //    }
            //}

            return result;
        }

        public static T Value<T>(this object objValue)
        {
            if (objValue == null || objValue == DBNull.Value)
                return default(T);
            Type destType = typeof(T);
            if (objValue.GetType() == destType)
                return (T)objValue;
            try
            {
                return (T)System.Convert.ChangeType(objValue, destType);
            }
            catch
            {
                return GetDefaultValue<T>(objValue.ToString());
            }
        }

        public static T Value<T>(this object objValue, T defaultValue)
        {
            if (objValue == null || objValue == DBNull.Value)
                return defaultValue;
            Type destType = typeof(T);
            if (objValue.GetType() == destType)
                return (T)objValue;
            try
            {
                return (T)System.Convert.ChangeType(objValue, destType);
            }
            catch
            {
                return GetDefaultValue<T>(objValue.ToString(), defaultValue);
            }
        }

        public static T GetDefaultValue<T>(string strValue, T defaultValue)
        {
            return InternalGetDefaultValue<T>(strValue, defaultValue, true);
        }
        internal static T InternalGetDefaultValue<T>(string strValue, T defaultValue,
          bool throwException)
        {
            Type type = typeof(T);
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            if (throwException)
            {
                //AtawDebug.AssertNotNull(converter, string.Format(ObjectUtil.SysCulture,
                //    "无法获取类型{0}的TypeConverter，请确认是否为其配置TypeConverterAttribute",
                //    type), null);
            }
            else
            {
                if (converter == null)
                    return default(T);
            }
            try
            {
                return strValue == null ? InternalGetDefaultValue(defaultValue)
                    : (T)converter.ConvertFromString(strValue);
            }
            catch
            {
                return InternalGetDefaultValue(defaultValue);
            }
        }
        private static T InternalGetDefaultValue<T>(T defaultValue)
        {
            if (defaultValue != null)
                return defaultValue;
            else
            {
                Type type = typeof(T);
                if (type.IsEnum)
                    return (T)GetFirstEnumValue(type);
                else
                    return default(T);
            }
        }
        public static T GetDefaultValue<T>(string strValue)
        {
            Type type = typeof(T);
            if (type.IsEnum)
                return GetDefaultValue(strValue, (T)GetFirstEnumValue(type));
            else
                return GetDefaultValue(strValue, default(T));
        }
        public static object GetFirstEnumValue(Type enumType)
        {
            //AtawDebug.AssertArgumentNull(enumType, "enumType", null);

            Array values = Enum.GetValues(enumType);
            //AtawDebug.Assert(values.Length > 0, string.Format(ObjectUtil.SysCulture,
            //    "枚举类型{0}中没有枚举值", enumType), null);
            return (values as IList)[0];
        }
    }
}
