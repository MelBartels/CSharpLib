using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GenLib.BitByte;
using GenLib.Extensions;
using Xunit;

namespace GenLibUnitTests.Extension
{
    public class FunctionalExtension
    {
        [Fact]
        public void HasValue()
        {
            var airplane = new Airplane();

            Assert.Null(airplane.WithValue(x => x.Engine));

            airplane.Engine = new Engine();
            Assert.NotNull(airplane.WithValue(x => x.Engine));
            Assert.IsType(typeof (Engine), airplane.WithValue(x => x.Engine));

            airplane.Engine.FuelType = "123";
            Assert.NotNull(airplane.WithValue(x => x.Engine.FuelType));
            Assert.IsType(typeof (string), airplane.WithValue(x => x.Engine.FuelType));
            Assert.Equal("123", airplane.WithValue(x => x.Engine.FuelType));
            Assert.Equal("123456", airplane.WithValue(x => x.Engine.FuelType + "456"));

            Assert.True(true);
        }

        [Fact]
        public void With()
        {
            var airplane = new Airplane();

            Assert.Null(airplane.With(x => airplane)
                            .With(x => x.Engine)
                            .With(x => x.FuelType));

            airplane.Engine = new Engine();
            Assert.Null(airplane.With(x => airplane)
                            .With(x => x.Engine)
                            .With(x => x.FuelType));

            airplane.Engine.FuelType = "123";
            Assert.NotNull(airplane.With(x => airplane)
                               .With(x => x.Engine)
                               .With(x => x.FuelType));

            Assert.True(true);
        }

        [Fact]
        public void AddIfNotContains()
        {
            Assert.Equal(3, 1.To(3).ToList().AddIfNotContains(2).Count);
            Assert.Equal(4, 1.To(3).ToList().AddIfNotContains(5).Count);

            List<int> foo = null;
            Assert.Null(foo.AddIfNotContains(5));

            Assert.True(true);
        }

        [Fact]
        public void Branch1()
        {
            var airplane = new Airplane {Engine = new Engine()};
            var hasEngine = string.Empty;
            airplane.With(a => a.Engine).Branch(_ => hasEngine = "yes", () => hasEngine = "no");
            Assert.Equal("yes", hasEngine);

            airplane.Engine = null;
            airplane.With(a => a.Engine).Branch(_ => hasEngine = "yes", () => hasEngine = "no");
            Assert.Equal("no", hasEngine);

            Assert.True(true);
        }

        [Fact]
        public void Branch2()
        {
            var airplane = new Airplane {Engine = new Engine {HasFuel = true}};
            var hasFuel = string.Empty;
            airplane.With(a => a.Engine).HasFuel.Branch(() => hasFuel = "yes", () => hasFuel = "no");
            Assert.Equal("yes", hasFuel);

            airplane.Engine.HasFuel = false;
            airplane.With(a => a.Engine).HasFuel.Branch(() => hasFuel = "yes", () => hasFuel = "no");
            Assert.Equal("no", hasFuel);

            Assert.True(true);
        }

        [Fact]
        public void Branch3()
        {
            var airplane = new Airplane { Engine = new Engine { HasFuel = true } };
            var hasFuel = string.Empty;
            airplane.With(a => a.Engine).Branch(e => e.HasFuel, _ => hasFuel = "yes", _ => hasFuel = "no");
            Assert.Equal("yes", hasFuel);

            airplane.Engine.HasFuel = false;
            airplane.With(a => a.Engine).Branch(e => e.HasFuel, _ => hasFuel = "yes", _ => hasFuel = "no");
            Assert.Equal("no", hasFuel);

            Assert.True(true);
        }

        [Fact]
        public void Return1()
        {
            var airplane = new Airplane();

            // if no fuelType, then return empty string
            Assert.Equal(string.Empty, airplane.With(x => airplane)
                                           .With(x => x.Engine)
                                           .Return(x => x.FuelType, string.Empty));

            airplane.Engine = new Engine {FuelType = "123"};
            Assert.Equal("123", airplane.With(x => airplane)
                                    .With(x => x.Engine)
                                    .Return(x => x.FuelType, string.Empty));

            Assert.True(true);
        }

        [Fact]
        public void Return2()
        {
            var airplane = new Airplane {Engine = new Engine {FuelType = "123"}};
            Func<string, string> func123 = s => s.Equals("123") ? "123 matches" : "123 does not match";
            Func<string, string> funcMissing = _ => "missing";

            Assert.Equal("123 matches", airplane.With(a => a.Engine).Return(e => func123, funcMissing)("123"));
            Assert.Equal("123 does not match", airplane.With(a => a.Engine).Return(e => func123, funcMissing)("456"));

            airplane.Engine = null;
            Assert.Equal("missing", airplane.With(a => a.Engine).Return(e => func123, funcMissing)("123"));

            Assert.True(true);
        }

        [Fact]
        public void Return3()
        {
            var airplane = new Airplane {Engine = new Engine {FuelType = "123"}};

            Assert.Equal("123", airplane.With(x => airplane)
                                    .With(x => x.Engine)
                                    .Return(x => x.FuelType, () => string.Empty));

            Assert.True(true);
        }

        [Fact]
        public void Return4()
        {
            var airplane = new Airplane {Engine = new Engine {FuelType = "123", HasFuel = true}};

            Assert.Equal("123", airplane.With(x => airplane)
                                    .With(x => x.Engine)
                                    .HasFuel
                                    .Return("123", string.Empty));

            Assert.True(true);
        }

        [Fact]
        public void Return5()
        {
            var airplane = new Airplane {Engine = new Engine {FuelType = "123", HasFuel = true}};

            Assert.Equal("123", airplane.With(x => airplane)
                                    .With(x => x.Engine)
                                    .HasFuel
                                    .Return(() => "123", () => string.Empty));

            Assert.True(true);
        }

        [Fact]
        public void If()
        {
            var airplane = new Airplane {Engine = new Engine()};

            Assert.Equal("crashing", airplane.With(x => airplane)
                                         .With(x => x.Engine)
                                         .If(x => x.HasFuel)
                                         .Return(x => "flying", "crashing"));
            var engine = airplane.With(x => airplane)
                .With(x => x.Engine)
                .If(x => x.HasFuel);
            Assert.Null(engine);

            airplane.Engine.HasFuel = true;
            Assert.Equal("flying", airplane.With(x => airplane)
                                       .With(x => x.Engine)
                                       .If(x => x.HasFuel)
                                       .Return(x => "flying", "crashing"));
            engine = airplane.With(x => airplane)
                .With(x => x.Engine)
                .If(x => x.HasFuel);
            Assert.NotNull(engine);

            Assert.True(true);
        }

        [Fact]
        public void IfNull()
        {
            var airplane = new Airplane();
            Assert.NotNull(airplane.IfNull(x => x.Engine));

            Assert.Equal("missing engine", airplane.IfNull(x => x.Engine)
                                               .Return(x => "missing engine", "has engine"));

            airplane.Engine = new Engine();
            Assert.Null(airplane.IfNull(x => x.Engine));

            Assert.True(true);
        }

        [Fact]
        public void IfNullGuids()
        {
            var airplane = new Airplane {Engine = new Engine()};
            Assert.Same(airplane, airplane.IfNull(x => (object) x.Engine.Guid));

            airplane.Engine.Guid = new Guid();
            Assert.Null(airplane.IfNull(x => (object) x.Engine.Guid));

            Assert.True(true);
        }

        [Fact]
        public void ReturnForIfThenElse()
        {
            var engine = new Engine();

            engine.HasFuel.Return(() => engine.FuelType = "123", () => engine.FuelType = "none");
            Assert.Equal("none", engine.FuelType);

            engine.HasFuel = true;
            engine.HasFuel.Return(() => engine.FuelType = "123", () => engine.FuelType = "none");
            Assert.Equal("123", engine.FuelType);

            Assert.True(true);
        }

        [Fact]
        public void IfReturn1()
        {
            var airplane = new Airplane {Engine = new Engine {HasFuel = true, FuelType = "123"}};
            Assert.Equal("123", airplane.IfReturn(a => a.Engine.HasFuel, a => a.Engine.FuelType, string.Empty));

            airplane.Engine.HasFuel = false;
            Assert.Equal(string.Empty, airplane.IfReturn(a => a.Engine.HasFuel, a => a.Engine.FuelType, string.Empty));

            Assert.True(true);
        }

        [Fact]
        public void IfReturn2()
        {
            var airplane = new Airplane { Engine = new Engine { HasFuel = true, FuelType = "123" } };
            Func<string, string> func123 = s => s.Equals("123") ? "123 matches" : "123 does not match";
            Func<string, string> funcMissing = _ => "missing";

            Assert.Equal("123 matches", airplane.With(a => a.Engine).IfReturn(e=>e.HasFuel, e => func123, funcMissing)("123"));
            Assert.Equal("123 does not match", airplane.With(a => a.Engine).IfReturn(e => e.HasFuel, e => func123, funcMissing)("456"));

            airplane.Engine = null;
            Assert.Equal("missing", airplane.With(a => a.Engine).IfReturn(e => e.HasFuel, e => func123, funcMissing)("123"));

            Assert.True(true);
        }

        [Fact]
        public void IfReturn3()
        {
            var airplane = new Airplane { Engine = new Engine { HasFuel = true, FuelType = "123" } };
            Assert.Equal("123", airplane.IfReturn(a => a.Engine.HasFuel, a => a.Engine.FuelType, () => string.Empty));

            airplane.Engine.HasFuel = false;
            Assert.Equal(string.Empty, airplane.IfReturn(a => a.Engine.HasFuel, a => a.Engine.FuelType, () => string.Empty));

            Assert.True(true);
        }

        [Fact]
        public void Then()
        {
            var engine = new Engine {HasFuel = true};
            engine.HasFuel.Then(() => engine.FuelType = "123");
            Assert.Equal("123", engine.FuelType);

            Assert.True(true);
        }

        [Fact]
        public void ThenElse()
        {
            var state = "begin";

// ReSharper disable AccessToModifiedClosure
            true.Then(() => state += " then").Else(() => state += " else");
// ReSharper restore AccessToModifiedClosure
            Assert.Equal("begin then", state);

            state = "begin";
            false.Then(() => state += " then").Else(() => state += " else");
            Assert.Equal("begin else", state);

            Assert.True(true);
        }

        [Fact]
        public void Else()
        {
            var engine = new Engine {FuelType = "123"};
            engine.HasFuel.Else(() => engine.FuelType = "none");
            Assert.Equal("none", engine.FuelType);

            Assert.True(true);
        }

        [Fact]
        public void Unless()
        {
            var airplane = new Airplane {Engine = new Engine()};

            Assert.Equal("crashing", airplane.With(x => airplane)
                                         .With(x => x.Engine)
                                         .Unless(x => x.HasFuel)
                                         .Return(x => "crashing", "flying"));

            airplane.Engine.HasFuel = true;
            Assert.Equal("flying", airplane.With(x => airplane)
                                       .With(x => x.Engine)
                                       .Unless(x => x.HasFuel)
                                       .Return(x => "crashing", "flying"));

            Assert.True(true);
        }

        [Fact]
        public void Using()
        {
            const string testValue = "123456789";
            var ms = new MemoryStream();
            ms.Write(new Encoder().StringToBytes(testValue), 0, testValue.Length);
            ms.Seek(0, 0);
            var results = new StreamReader(ms).Using(f => f.ReadToEnd());
            Assert.Equal(testValue, results);

            Assert.True(true);
        }

        [Fact]
        public void Do()
        {
            var airplane = new Airplane {Engine = new Engine {FuelType = "123", HasFuel = true}};

            Assert.Equal("correct fuel", airplane.With(x => airplane)
                                             .With(x => x.Engine)
                                             .Do(FillupAndTestFuelGrade())
                                             .If(x => x.FuelTypeTest)
                                             .Return(x => "correct fuel", "bad fuel"));

            airplane.Engine.FuelType = "999";
            Assert.Equal("bad fuel", airplane.With(x => airplane)
                                         .With(x => x.Engine)
                                         .Do(FillupAndTestFuelGrade())
                                         .If(x => x.FuelTypeTest)
                                         .Return(x => "correct fuel", "bad fuel"));

            Assert.True(true);
        }

        [Fact]
        public void DoAction()
        {
            var action = new ActionContainer();
            action.Action = action.SetActionOccurredTrue;
            action.With(a => a.Action).DoAction();
            // otherwise action.With(a => a.Action).Do(a => a.Invoke());
            // or even action.With(a => a.Action)();
            Assert.True(action.ActionOccurred);

            action.Action = null;
            action.With(a => a.Action).DoAction();

            Assert.True(true);
        }

        [Fact]
        public void DoActionWithParm()
        {
            var action = new ActionContainer();
            action.ActionBool = action.SetActionOccurred;
            action.With(a => a.ActionBool).DoAction(true);
            Assert.True(action.ActionOccurred);

            Assert.True(true);
        }

        [Fact]
        public void NullOperation()
        {
            Airplane plane = null;
            plane.DoWhenNull(() => plane = new Airplane());

            plane.ShouldNotBeNull();
        }

        [Fact]
        public void BothNullOperation()
        {
            Airplane plane = null;
            plane.Do(p => p.Engine = new Engine {HasFuel = true})
                .DoWhenNull(() => plane = new Airplane {Engine = new Engine {FuelType = "None"}});

            plane.Engine.FuelType.ShouldBe("None");
            plane.Engine.HasFuel.ShouldBeFalse();
        }

        [Fact]
        public void CastSafe()
        {
            var airplane = new Airplane();
            Assert.NotNull(airplane.CastSafe<IAirplane>());
            Assert.Null(airplane.CastSafe<Engine>());

            Assert.Null(airplane.CastSafe<IAirplane>().Engine);
            airplane.Engine = new Engine();
            Assert.NotNull(airplane.CastSafe<IAirplane>().Engine);

            Assert.True(true);
        }

        [Fact]
        public void Guard()
        {
            // cast guard
            var jet = new Jet();
            Assert.Null(jet.CastSafe<Airplane>());

            // null guard
            var airplane = new Airplane();
            Assert.Null(airplane.With(a => a.Engine));

            // condition guard
            airplane.Engine = new Engine();
            Assert.Null(airplane.If(a => a.Engine.HasFuel));

            // all guards pass
            airplane.Engine.HasFuel = true;
            var result = string.Empty;
            airplane.CastSafe<Airplane>().With(a => a.Engine).If(e => e.HasFuel).Do(e => result = "success");
            Assert.Equal("success", result);

            Assert.True(true);
        }

        [Fact]
        public void ObjectWithNullAction()
        {
            ObjectWithAction owa = null;
            owa.With(o => o.Action).DoAction();

            owa = new ObjectWithAction();
            owa.With(o => o).Action.DoAction();

            owa.Action = owa.SetResultTrue;
            owa.With(o => o).Action.DoAction();
            Assert.True(owa.Result);

            Assert.True(true);
        }

        [Fact]
        public void SetPropertiesFrom()
        {
            var cwp = new ClassWithProperties
                          {
                              MyBool = true,
                              MyInt = 5,
                              MyString = "hello world",
                              MyDouble = 2.2,
                              MyBoolPrivateGetter = true
                          };
            cwp.SetMyBoolPrivateSetter(true);

            var cwp2 = new ClassWithProperties();
            Assert.Equal(false, cwp2.MyBool);
            Assert.Equal(false, cwp2.GetMyBoolPrivateGetter());

            cwp2.SetPropertiesFrom(cwp);
            Assert.Equal(true, cwp2.MyBool);
            Assert.Equal(5, cwp2.MyInt);
            Assert.Equal("hello world", cwp2.MyString);
            Assert.Equal(2.2, cwp2.MyDouble);
            // public set and get required
            Assert.Equal(false, cwp2.GetMyBoolPrivateGetter());
            Assert.Equal(false, cwp2.MyBoolPrivateSetter);

            Assert.True(true);
        }

        [Fact]
        public void Clone()
        {
            var cwp = new ClassWithProperties();
            var cwp2 = cwp.Clone();

            Assert.NotNull(cwp2);
            Assert.NotSame(cwp, cwp2);

            Assert.True(true);
        }

        [Fact]
        public void CloneThenSetPropertiesFrom()
        {
            var cwp = new ClassWithProperties {MyBool = true};
            var cwp2 = cwp.CloneAndSetPropertiesFrom();

            Assert.NotSame(cwp, cwp2);
            Assert.Equal(true, cwp2.MyBool);

            Assert.True(true);
        }

        [Fact]
        public void CloneAndSetPropertiesFrom()
        {
            var cwp = new ClassWithProperties
                          {
                              MyBool = true,
                              MyInt = 5,
                              MyString = "hello world",
                              MyDouble = 2.2,
                              MyBoolPrivateGetter = true
                          }.CloneAndSetPropertiesFrom();

            Assert.Equal(true, cwp.MyBool);

            Assert.True(true);
        }

        [Fact]
        public void Each()
        {
            var count = 0;
            5.Each().ForEach(x => count++);
            Assert.Equal(5, count);

            Assert.True(true);
        }

        [Fact]
        public void To()
        {
            var r = 1.To(11);
            Assert.Equal(11, r.Count());
            Assert.Equal(1, r.ElementAt(0));

            r = 11.To(1);
            Assert.Equal(11, r.Count());
            Assert.Equal(11, r.ElementAt(0));

            r = (-1).To(9);
            Assert.Equal(11, r.Count());
            Assert.Equal(-1, r.ElementAt(0));

            r = (-1).To(-11);
            Assert.Equal(11, r.Count());
            Assert.Equal(-1, r.ElementAt(0));

            r = 1.To(-9);
            Assert.Equal(11, r.Count());
            Assert.Equal(1, r.ElementAt(0));

            Assert.True(true);
        }

        [Fact]
        public void EnumExamples()
        {
            // examples of using methods to avoid mixing enums with functional extensions
            Assert.True((GetEnum() == TestingEnum.TestingTwo));
            Assert.True(EnumMatches(GetEnum()));

            // encapsulate enum to work with functional extensions
            var oe = new {B = true, E = GetEnum()};
            Assert.True(oe.B && EnumMatches(oe.E));
            Assert.Equal("yes", oe.If(oe1 => oe1.B && EnumMatches(oe1.E)).Return(_ => "yes", "no"));

            Assert.True(true);
        }

        private static Action<Engine> FillupAndTestFuelGrade()
        {
            return x =>
                       {
                           x.HasFuel = true;
                           x.FuelTypeTest = x.FuelType == "123";
                       };
        }

        private static TestingEnum GetEnum()
        {
            return TestingEnum.TestingTwo;
        }

        private static bool EnumMatches(TestingEnum testingEnum)
        {
            return testingEnum == TestingEnum.TestingTwo;
        }

        #region Nested type: ActionContainer

        private class ActionContainer
        {
            public Action Action { get; set; }
            public Action<bool> ActionBool { get; set; }
            public bool ActionOccurred { get; set; }

            public void SetActionOccurredTrue()
            {
                ActionOccurred = true;
            }

            public void SetActionOccurred(bool value)
            {
                ActionOccurred = value;
            }
        }

        #endregion

        #region Nested type: ClassWithProperties

        private class ClassWithProperties
        {
            public bool MyBool { get; set; }
            public int MyInt { get; set; }
            public string MyString { get; set; }
            public double MyDouble { get; set; }
            public bool MyBoolPrivateGetter { private get; set; }
            public bool MyBoolPrivateSetter { get; private set; }

            public bool MyBoolNoGetter
            {
                set { }
            }

            public bool MyBoolNoSetter
            {
                get { return true; }
            }

            public bool GetMyBoolPrivateGetter()
            {
                return MyBoolPrivateGetter;
            }

            public void SetMyBoolPrivateSetter(bool value)
            {
                MyBoolPrivateGetter = value;
            }
        }

        #endregion

        #region Nested type: ObjectWithAction

        private class ObjectWithAction
        {
            public Action Action { get; set; }
            public bool Result { get; private set; }

            public void SetResultTrue()
            {
                Result = true;
            }
        }

        #endregion
    }
}