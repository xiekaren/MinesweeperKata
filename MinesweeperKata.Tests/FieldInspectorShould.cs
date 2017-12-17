﻿using System.Collections.Generic;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    public class FieldInspectorShould
    {
        private FieldInspector _fieldInspector;

        [SetUp]
        public void SetUp()
        {
            _fieldInspector = new FieldInspector();
        }

        [Test]
        public void GetMineLocationsForField()
        {
            var mineFieldValues = new Dictionary<string, int>
            {
                {"00", 0},
                {"01", -1},
                {"10", 0},
                {"11", -1}
            };
            var mineField = new Minefield(mineFieldValues);
            var expected = new List<string> {"01", "11"};

            var result = _fieldInspector.GetMineLocations(mineField);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetMineLocationsForFieldEmpty()
        {
            var mineFieldValues = new Dictionary<string, int>
            {
                {"00", 0},
                {"01", 0},
                {"10", 0},
                {"11", 0}
            };
            var mineField = new Minefield(mineFieldValues);
            var expected = new List<string>();

            var result = _fieldInspector.GetMineLocations(mineField);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetMineNeighbours()
        {
            var mineFieldValues = new Dictionary<string, int>()
            {
                {"00", -1},
                {"01", 0},
                {"10", 0},
                {"11", 0}
            };
            var mineLocations = new List<string> {"00"};
            var mineField = new Minefield(mineFieldValues);
            var expected = new List<string> {"01", "10", "11"};

            var result = _fieldInspector.GetMineNeighbours(mineField, mineLocations);

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}