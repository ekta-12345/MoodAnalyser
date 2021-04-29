using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyserPrb;


namespace MSTestMoodAnalyzer
{

    [TestClass]
    public class UnitTest1  //Class
    {
        /* TC 1.1:- Given “I am in Sad Mood” message Should Return SAD
                    - analyseMood method can just return SAD to pass this Test Case (TC)
        */
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

        // TC 1.2
        [TestMethod]
        public void Given_Happymood_Expecting_Happy_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer("I am in happy mood"); //Create object and arrange 
            string expected = "happy";

            string actual = mood.Analyzer();    //act
            Assert.AreEqual(expected, actual);  //Assert
        }

        /* UC2:- Handle Exception if User Provides Invalid Mood
         */
        [TestMethod]
        public void Given_Nullmood_Expecting_Exception_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(null); //Create object and arrange 
            string expected = "Object reference not set to an instance of an object.";

            string actual = mood.Analyzer();    //act

            Assert.AreEqual(expected, actual);  //Assert
        }

        /* TC 2.1:- Given Null Mood Should Return Happy.
                   - To make this Test Case pass Handle NULL Scenario using try catch and return Happy.
        */
        [TestMethod]
        public void Given_Nullmood_Expecting_happy_Result()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(null); //Create object and arrange 
            string expected = "happy";

            string actual = mood.Analyzer();    //act

            Assert.AreEqual(expected, actual);  //Assert
        }

        /* TC 3.1:- NULL Given NULL Mood Should Throw MoodAnalysisException
                    To pass this Test Case in try catch block throw MoodAnalysisException
         */
        [TestMethod]
        public void Given_Nullmood_Using_CustomExpection_Return_Null()  //Method
        {
            MoodAnalyzer mood = new MoodAnalyzer(null); //Create object and arrange 
            //string actual = "";
            string actual = "";

            try
            {
                actual = mood.Analyzer();    //act

            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("Mood should not be null", exception.Message);  //Assert
            }
        }

        // TC 3.2
        [TestMethod]
        public void Given_Emptymood_Using_CustomExpection_Return_Empty()  //Method
        {

            string actual = "";

            try
            {
                string message = string.Empty;
                MoodAnalyzer mood = new MoodAnalyzer(message); //Create object and arrange 
                actual = mood.Analyzer();    //act

            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("Mood should not be empty", exception.Message);  //Assert
            }

        }
        // TC 4.1


        [TestMethod]
        public void GivenMoodAnalyseClass_ShouldReturn_MoodAnalyserObject()
        {
            string message = null;
            object expected = new MoodAnalyzer(message);
            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            object obj = factory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }

        //TC 4.2

        [TestMethod]
        public void MoodAnalyseClass_GivenWrongClassName_ShouldReturn_NOClassException()
        {
            string expected = "Class not found";
            try
            {
                string message = null;
                object moodAnalyser = new MoodAnalyzer(message);
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object obj = factory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
                moodAnalyser.Equals(obj);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }
        //TC 4.3

        [TestMethod]
        public void MoodAnalyseClass_GivenWrongConstructorName_ShouldReturn_NoConstructorException()
        {
            string expected = "Constructor not found";
            try
            {
                string message = null;
                object moodAnalyser = new MoodAnalyzer(message);
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                object obj = factory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer");
                moodAnalyser.Equals(obj);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }

       // TC 5.1
        [TestMethod]
        public void Given_MoodAnalyzer_Using_Reflection_Return_ParameterConstructor()  //Method
        {
            string message = "I am in happy mood";
            MoodAnalyzer expected = new MoodAnalyzer("I am in happy mood"); //Create object and arrange 
            object obj = null;
            //string actual = "";
            // string expected = "Mood should not be empty";

            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyzerParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
            }
            catch (MoodAnalyserException exception)
            {

            }
            obj.Equals(expected);

        }

        // TC 5.2
         
        [TestMethod]
        public void MoodAnalyseClass_GivenWrongClassName_ShouldReturn_NoClassException_UsingParameterizedConstrucor()
        {
            string expected = "Class not found";
            object obj = null;
            try
            {
                string message = "Happy";

                object moodAnalyser = new MoodAnalyzer(message);
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyzerParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                moodAnalyser.Equals(obj);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }

        //TC 5.3
        
        [TestMethod]
        public void MoodAnalyseClass_GivenWrongConstructorName_ShouldReturn_NoConstructorException_UsingParameterizedConstrucor()
        {
            string expected = "Constructor not found";
            object obj = null;
            try
            {
                string message = "Happy";

                object moodAnalyser = new MoodAnalyzer(message);
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyzerParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                moodAnalyser.Equals(obj);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }
        //UC6 TC1&TC2
        [TestMethod]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string message = "I am in happy mood";
            MoodAnalyzer expected = new MoodAnalyzer("I am in happy mood");
            object obj = null;
            try
            {
                MoodAnalyserFactory Factory = new MoodAnalyserFactory();
                obj = Factory.InvokeAnalyzerMethod(message, "Analyzer");
            }
            catch (MoodAnalyserException exception)
            {

                throw new Exception(exception.Message);
            }
            obj.Equals(expected);
        }


    }
}

    
