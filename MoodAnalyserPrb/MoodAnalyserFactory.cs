using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;


namespace MoodAnalyserPrb
{
    class MoodAnalyserFactory
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


    }
}

