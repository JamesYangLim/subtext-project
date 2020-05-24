using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubtextProject;
using System.Diagnostics;
using System.Linq;

namespace SubtextProjectTest
{
    [TestClass]
    public class SubtextTest
    {
        [TestMethod]
        public void BasicTest()
        {
            var subtext = new Subtext("abcdef", "d");
            var positions = subtext.FindAllSubtextPositions();
            Assert.AreEqual(1, positions.Count);
            Assert.AreEqual(3, positions[0]);
        }

        [TestMethod]
        public void NoMatchesTest()
        {
            var subtext = new Subtext("abcdef", "z");
            var positions = subtext.FindAllSubtextPositions();
            Assert.AreEqual(0, positions.Count);
        }

        [TestMethod]
        public void MultipleMatchesTest()
        {
            var subtext = new Subtext("Hello World!", "l");
            var positions = subtext.FindAllSubtextPositions();
            Assert.AreEqual(3, positions.Count);
            Assert.AreEqual(2, positions[0]);
            Assert.AreEqual(3, positions[1]);
            Assert.AreEqual(9, positions[2]);
        }

        [TestMethod]
        public void CaseInsensitiveMatchesTest()
        {
            var subtext = new Subtext("I Love Lollipop", "l");
            var positions = subtext.FindAllSubtextPositions();
            Assert.AreEqual(4, positions.Count);
            Assert.AreEqual(2, positions[0]);
            Assert.AreEqual(7, positions[1]);
            Assert.AreEqual(9, positions[2]);
            Assert.AreEqual(10, positions[3]);
        }

        [TestMethod]
        public void TongueTwisterTest()
        {
            var tongureTwister = "" +
                "Peter Piper picked a peck of pickled peppers " + // 9 Ps
                "A peck of pickled peppers Peter Piper picked " + // 9 Ps
                "If Peter Piper picked a peck of pickled peppers " + // 9 Ps
                "Where’s the peck of pickled peppers Peter Piper picked?"; // 9 Ps

            var subtext = new Subtext(tongureTwister, "p");
            var positions = subtext.FindAllSubtextPositions();
            Assert.AreEqual(36, positions.Count);
        }

        [TestMethod]
        public void TongueTwisterTest2()
        {
            var tongureTwister = "" +
                "Betty Botter bought some butter " +
                "But she said the butter’s bitter " +
                "If I put it in my batter, it will make my batter bitter " + 
                "But a bit of better butter will make my batter better " + 
                "So ‘twas better Betty Botter bought a bit of better butter"; 

            var subtext = new Subtext(tongureTwister, "butter");
            var positions = subtext.FindAllSubtextPositions();
            Assert.AreEqual(4, positions.Count);
            Assert.AreEqual(25, positions[0]);
            Assert.AreEqual(49, positions[1]);
            Assert.AreEqual(141, positions[2]);
            Assert.AreEqual(227, positions[3]);
        }
    }
}
