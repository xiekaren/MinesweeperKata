using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;
using MinesweeperKata.FieldHints;
using NUnit.Framework;

namespace MinesweeperKata.Tests.FieldHints
{
    [TestFixture]
    public class HinterShould
    {
        private Hinter _hinter;

        [SetUp]
        public void Setup()
        {
            _hinter = new Hinter();
        }

        [Test]
        public void GetHintsForField()
        {
            var field = new Field
            {
                Rows = 1,
                Columns = 1,
                Locations = new List<Point>
                {
                    new Point {Row = 0, Column = 0, IsMine = true}
                }
            };

            var expectedHint = new List<string>
            {
                "*"
            };
            

            var result = _hinter.GetHintsFor(field);

            Assert.AreEqual(expectedHint, result);

        }

        [Test]
        public void GetHintsForField2()
        {
            var field = new Field
            {
                Rows = 2,
                Columns = 3,
                Locations = new List<Point>
                {
                    new Point {Row = 0, Column = 0, IsMine = false}, new Point {Row = 0, Column = 1, IsMine = true}, new Point {Row = 0, Column = 2, IsMine = true},
                    new Point {Row = 1, Column = 0, IsMine = true}, new Point {Row = 1, Column = 1, IsMine = true}, new Point {Row = 1, Column = 2, IsMine = true},
                }
            };

            var expectedHint = new List<string>
            {
                "3", "*", "*",
                "*", "*", "*",
            };


            var result = _hinter.GetHintsFor(field);

            Assert.AreEqual(expectedHint, result);

        }

        [Test]
        public void TransformFieldsToHints()
        {
            var fields = new List<Field>
            {
                new Field
                {
                    Rows = 1, Columns = 1,
                    Locations = new List<Point> {new Point {Row = 0, Column = 0, IsMine = false}}
                },
                new Field
                {
                    Rows = 2, Columns = 2,
                    Locations = new List<Point>
                    {
                        new Point {Row = 0, Column = 0, IsMine = false},
                        new Point {Row = 0, Column = 1, IsMine = true},
                        new Point {Row = 1, Column = 0, IsMine = true},
                        new Point {Row = 1, Column = 1, IsMine = false}
                    }
                }
            };

            var expected = new List<HintField>
            {
                new HintField
                {
                    Rows = 1, Columns = 1,
                    FieldHints = new List<string>
                    {
                        "0"
                    }
                },
                new HintField
                {
                    Rows = 2, Columns = 2,
                    FieldHints = new List<string>
                    {
                        "2", "*",
                        "*", "2"
                    }
                }
            };

            var result = _hinter.FieldsToHints(fields);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
