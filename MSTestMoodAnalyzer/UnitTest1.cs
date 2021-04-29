using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyserPrb;


namespace MSTestMoodAnalyzer
{
    [TestClass]
    public class UnitTest1

    //Class
    /* TC 1.1:- Given “I am in Sad Mood” message Should Return SAD
                   - analyseMood method can just return SAD to pass this Test Case (TC)
       */
    {
        [TestMethod]
        public void AnalyseMood_ShouldReturn_Sad()
        {
            //Arraneg
            string expected = "sad";
            MoodAnalyzer obj = new MoodAnalyzer("I am in sad Mood");
            //Act
            string actual = obj.Analyzer();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /* TC 1.2:- Given “I am in Any Mood” message Should Return HAPPY.
                    - To make the Test case pass analyseMood method need to check for Sad else return HAPPY
       */
        [TestMethod]
        public void Given_Happymood_Expecting_Happy_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer("I am in happy mood"); //Create object and arrange 
            string expected = "happy";

            string actual = mood.Analyzer();    //act
            Assert.AreEqual(expected, actual);  //Assert
        }
    }
}


