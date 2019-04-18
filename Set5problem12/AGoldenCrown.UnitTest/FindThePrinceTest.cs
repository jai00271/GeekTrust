using System;
using System.Collections.Generic;
using Xunit;

namespace AGoldenCrown.UnitTest
{
    public class FindThePrinceTest
    {
        private FindThePrince findThePrince;
        private readonly string question_ruler = "Who is the ruler of Southeros?";
        private readonly string question_allies = "Allies of Ruler?";


        public FindThePrinceTest()
        {
            FindThePrince findThePrince = new FindThePrince();
        }

        [Fact]
        public void GivenNoInputMessage_WhenRulerFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_ruler;

            //Act
            var response  = FindThePrince.WhoIsTheRuler(question);

            //Assert
            Assert.Equal("None", response);
        }

        [Fact]
        public void GivenNoInputMessage_WhenAlliesFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_allies;

            //Act
            var response = Convert.ToString(FindThePrince.WhoAreTheAlliesOfRuler(question));

            //Assert
            Assert.Equal("None", response);
        }
        [Fact]
        public void GivenWrongInputMessage_WhenRulerFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_ruler;

            //Act
            var response = Convert.ToString(FindThePrince.WhoAreTheAlliesOfRuler(question));

            //Assert
            Assert.Equal("None", response);
        }
        [Fact]
        public void GivenWrongInputMessage_WhenAlliesFindBegins_ThenItReturnsNone()
        {
            //Arrange
            string question = question_allies;

            //Act
            var response = Convert.ToString(FindThePrince.WhoAreTheAlliesOfRuler(question));

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
            var response = Convert.ToString(FindThePrince.WhoAreTheAlliesOfRuler(question));

            //Assert
            Assert.Equal("Shan", response);
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
            var response = Convert.ToString(FindThePrince.WhoAreTheAlliesOfRuler(question));

            //Assert
            Assert.Contains("Air", response);
            Assert.Contains("Land", response);
            Assert.Contains("Ice", response);
        }
    }
}