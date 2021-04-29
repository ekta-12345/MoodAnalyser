using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;


namespace MoodAnalyserPrb
{
    public class MoodAnalyserFactory
    {
        public object CreateMoodAnalyzerObject(string className, string constructor)
        {
            //MoodAnalyzerProblem.MoodAnalyzer
            string pattern = @"." + constructor + "$";
            Match result = Regex.Match(className, pattern); //regex predefine class .pattern matching store result suppose pattern matching then create object than an constructor

            if (result.Success) //success boolen property sucess hold true value other wise false //classma,e and patytern both are matching
            {
                try
                {    //constructor and classname both are matching

                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyzerType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyzerType); //Activator class
                    return res;
                }
                catch (NullReferenceException)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "class not found");//class name not maching that time we run
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "constructor not found");//Constructor name not maching that time we run
            }
        }

        //UC5
        public Object CreateMoodAnalyzerParameterObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyzer);

            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {

                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorObject = type.GetConstructor(new[] { typeof(string) });
                    Object instance = constructorObject.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class not found");

            }
        }
        // UC6
        public string InvokeAnalyzerMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyzer);

                MethodInfo analyzerMoodInfo = type.GetMethod(methodName);
                MoodAnalyserFactory Factory = new MoodAnalyserFactory();
                object moodAnalyzerObject = Factory.CreateMoodAnalyzerParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                object mood = analyzerMoodInfo.Invoke(moodAnalyzerObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Method is not found");
            }
        }
        // UC7:- Use Reflection to change mood dynamically 

        public static string SetField(string message, string fieldName)
        {
            try
            {
                if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL, "Mood should not be NULL");
                }

                MoodAnalyzer obj = new MoodAnalyzer();

                Type type = Type.GetType("MoodAnalyserProblem.MoodAnalyzer");

                FieldInfo field = type.GetField(fieldName);

                field.SetValue(obj, message);

                return obj.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, "No Such Field");
            }

        }
    }
}
         
