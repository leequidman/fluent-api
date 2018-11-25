﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace ObjectPrinting.Tests
{
    [TestFixture]
    class ObjectPrinting_Should
    {
        private PrintingConfig<Person> printer;
        private Person person;
        [SetUp]
        public void SetUp()
        {
            printer = ObjectPrinter.For<Person>();
            person = new Person
            {
                Id = Guid.Empty,
                Name = "John Smith",
                Age = 69,
                Height = 13.37
            };
        }

        [Test]
        public void ObjectPrinter_ShouldExcludeTypeFromSerialization()
        {
            var expected = string.Join(Environment.NewLine, "Person", "\tId = Guid", "\tName = John Smith", "\tHeight = 13,37")
                           + Environment.NewLine;
            printer.Excluding<int>();
            printer.PrintToString(person).Should().Be(expected);
        }
    }
}