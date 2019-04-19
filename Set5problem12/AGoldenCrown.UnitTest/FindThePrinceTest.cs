using AGoldenCrown.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace AGoldenCrown.UnitTest
{
    public class FindThePrinceTest
    {
        private readonly string question_ruler = "Who is the ruler of Southeros?";
        private readonly string question_allies = "Allies of";
        public readonly IRulerOfSoutheros rulerOfSoutheros;
        public readonly IAlliesOfRuler alliesOfRuler;

        public FindThePrinceTest()
        {
            rulerOfSoutheros = new RulerOfSoutheros();
            alliesOfRuler = new AlliesOfRuler();
        }

        #region RulerSearch

        [Fact]
        public void GivenNoInputMessage_WhenRulerFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_ruler;
            List<string> inputMessages = new List<string>();

            //Act
            var response = rulerOfSoutheros.SearchRuler(question, inputMessages);

            //Assert
            Assert.Equal("None", response);
        }

        [Fact]
        public void GivenWrongInputMessage_WhenRulerFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_ruler;
            List<string> inputMessages = new List<string>();

            //Act
            var response = Convert.ToString(rulerOfSoutheros.SearchRuler(question, inputMessages));

            //Assert
            Assert.Equal("None", response);
        }

        [Fact]
        public void GivenCorrectInputMessage_WhenRulerFindBegins_ThenItReturnsKingName()
        {
            //Arrange
            string question = question_ruler;
            List<string> inputMessages = new List<string>();
            inputMessages.Add("Air, “oaaawaala”");
            inputMessages.Add("Land, “a1d22n333a4444p”");
            inputMessages.Add("Ice, “zmzmzmzaztzozh”");

            //Act
            var response = Convert.ToString(rulerOfSoutheros.SearchRuler(question, inputMessages));

            //Assert
            Assert.Contains("King Shan", response);
        }

        [Fact]
        public void GivenInCorrectInputMessage_WhenRulerFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_ruler;
            List<string> inputMessages = new List<string>();
            inputMessages.Add("Air, “oaaawaaa”");
            inputMessages.Add("Land, “a1d22n333a4444p”");
            inputMessages.Add("Ice, “zmzmzmzaztzozh”");

            //Act
            var response = Convert.ToString(rulerOfSoutheros.SearchRuler(question, inputMessages)).TrimStart(',');

            //Assert
            Assert.Equal("None", response);
        }

        #endregion RulerSearch

        #region AlliesSearch

        [Fact]
        public void GivenNoInputMessage_WhenAlliesFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_allies;
            List<string> inputMessages = new List<string>();

            //Act
            var response = Convert.ToString(alliesOfRuler.WhoAreTheAlliesOfRuler(question, inputMessages));

            //Assert
            Assert.Equal("None", response);
        }


        [Fact]
        public void GivenWrongInputMessage_WhenAlliesFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_allies;
            List<string> inputMessages = new List<string>();

            //Act
            var response = Convert.ToString(alliesOfRuler.WhoAreTheAlliesOfRuler(question, inputMessages));

            //Assert
            Assert.Equal("None", response);
        }


        [Fact]
        public void GivenCorrectInputMessage_WhenAlliesFindBegins_ThenItReturnsKingName()
        {
            //Arrange
            string question = question_allies;
            List<string> inputMessages = new List<string>();
            inputMessages.Add("Air, “oaaawaala”");
            inputMessages.Add("Land, “a1d22n333a4444p”");
            inputMessages.Add("Ice, “zmzmzmzaztzozh”");

            //Act
            var response = Convert.ToString(alliesOfRuler.WhoAreTheAlliesOfRuler(question, inputMessages)).TrimStart(',');

            //Assert
            Assert.Contains("Air", response);
            Assert.Contains("Land", response);
            Assert.Contains("Ice", response);
        }

        [Fact]
        public void GivenLessThan3InputMessage_WhenAlliesFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_allies;
            List<string> inputMessages = new List<string>();
            inputMessages.Add("Air, “oaaawaala”");
            inputMessages.Add("Land, “a1d22n333a4444p”");

            //Act
            var response = Convert.ToString(alliesOfRuler.WhoAreTheAlliesOfRuler(question, inputMessages)).TrimStart(',');

            //Assert
            Assert.Contains("None", response);
        }

        

        #endregion AlliesSearch
    }
}