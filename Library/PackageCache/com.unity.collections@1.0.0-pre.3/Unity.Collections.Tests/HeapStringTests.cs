#if !UNITY_DOTSRUNTIME
#pragma warning disable 618
using System;
using NUnit.Framework;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using System.Text;

namespace FixedStringTests
{

    internal class HeapStringTests
    {
        [Test]
        public void HeapStringFixedStringCtors()
        {
            using (HeapString aa = new HeapString(new FixedString32("test32"), Allocator.Temp))
            {
                Assert.True(aa != new FixedString32("test"));
                Assert.True(aa.Value == "test32");
                Assert.AreEqual("test32", aa);
            }

            using (HeapString aa = new HeapString(new FixedString64("test64"), Allocator.Temp))
            {
                Assert.True(aa != new FixedString64("test"));
                Assert.True(aa.Value == "test64");
                Assert.AreEqual("test64", aa);
            }

            using (HeapString aa = new HeapString(new FixedString128("test128"), Allocator.Temp))
            {
                Assert.True(aa != new FixedString128("test"));
                Assert.True(aa.Value == "test128");
                Assert.AreEqual("test128", aa);
            }

            using (HeapString aa = new HeapString(new FixedString512("test512"), Allocator.Temp))
            {
                Assert.True(aa != new FixedString512("test"));
                Assert.True(aa.Value == "test512");
                Assert.AreEqual("test512", aa);
            }

            using (HeapString aa = new HeapString(new FixedString4096("test4096"), Allocator.Temp))
            {
                Assert.True(aa != new FixedString4096("test"));
                Assert.True(aa.Value == "test4096");
                Assert.AreEqual("test4096", aa);
            }
        }

        [Test]
        public void HeapStringFormatExtension1Params()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            Assert.True(aa.IsCreated);
            aa.Junk();
            FixedString32 format = "{0}";
            FixedString32 arg0 = "a";
            aa.AppendFormat(format, arg0);
            aa.Add(0x61);
            Assert.AreEqual("aa", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }

        [Test]
        public void HeapStringCorrectLengthAfterClear()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            Assert.True(aa.IsCreated);
            Assert.AreEqual(0, aa.Length, "Length after creation is not 0");
            aa.AssertNullTerminated();

            aa.Junk();

            aa.Clear();
            Assert.AreEqual(0, aa.Length, "Length after clear is not 0");
            aa.AssertNullTerminated();

            aa.Dispose();
        }

        [Test]
        public void HeapStringFormatExtension2Params()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Junk();
            FixedString32 format = "{0} {1}";
            FixedString32 arg0 = "a";
            FixedString32 arg1 = "b";
            aa.AppendFormat(format, arg0, arg1);
            Assert.AreEqual("a b", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }


        [Test]
        public void HeapStringFormatExtension3Params()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Junk();
            FixedString32 format = "{0} {1} {2}";
            FixedString32 arg0 = "a";
            FixedString32 arg1 = "b";
            FixedString32 arg2 = "c";
            aa.AppendFormat(format, arg0, arg1, arg2);
            Assert.AreEqual("a b c", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }


        [Test]
        public void HeapStringFormatExtension4Params()
        {
            HeapString aa = new HeapString(Allocator.Temp);
            aa.Junk();
            FixedString32 format = "{0} {1} {2} {3}";
            FixedString32 arg0 = "a";
            FixedString32 arg1 = "b";
            FixedString32 arg2 = "c";
            FixedString32 arg3 = "d";
            aa.AppendFormat(format, arg0, arg1, arg2, arg3);
            Assert.AreEqual("a b c d", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }


        [Test]
        public void HeapStringFormatExtension5Params()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Junk();
            FixedString32 format = "{0} {1} {2} {3} {4}";
            FixedString32 arg0 = "a";
            FixedString32 arg1 = "b";
            FixedString32 arg2 = "c";
            FixedString32 arg3 = "d";
            FixedString32 arg4 = "e";
            aa.AppendFormat(format, arg0, arg1, arg2, arg3, arg4);
            Assert.AreEqual("a b c d e", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }


        [Test]
        public void HeapStringFormatExtension6Params()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Junk();
            FixedString32 format = "{0} {1} {2} {3} {4} {5}";
            FixedString32 arg0 = "a";
            FixedString32 arg1 = "b";
            FixedString32 arg2 = "c";
            FixedString32 arg3 = "d";
            FixedString32 arg4 = "e";
            FixedString32 arg5 = "f";
            aa.AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5);
            Assert.AreEqual("a b c d e f", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }


        [Test]
        public void HeapStringFormatExtension7Params()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Junk();
            FixedString32 format = "{0} {1} {2} {3} {4} {5} {6}";
            FixedString32 arg0 = "a";
            FixedString32 arg1 = "b";
            FixedString32 arg2 = "c";
            FixedString32 arg3 = "d";
            FixedString32 arg4 = "e";
            FixedString32 arg5 = "f";
            FixedString32 arg6 = "g";
            aa.AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            Assert.AreEqual("a b c d e f g", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }


        [Test]
        public void HeapStringFormatExtension8Params()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Junk();
            FixedString128 format = "{0} {1} {2} {3} {4} {5} {6} {7}";
            FixedString32 arg0 = "a";
            FixedString32 arg1 = "b";
            FixedString32 arg2 = "c";
            FixedString32 arg3 = "d";
            FixedString32 arg4 = "e";
            FixedString32 arg5 = "f";
            FixedString32 arg6 = "g";
            FixedString32 arg7 = "h";
            aa.AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            Assert.AreEqual("a b c d e f g h", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }


        [Test]
        public void HeapStringFormatExtension9Params()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Junk();
            FixedString128 format = "{0} {1} {2} {3} {4} {5} {6} {7} {8}";
            FixedString32 arg0 = "a";
            FixedString32 arg1 = "b";
            FixedString32 arg2 = "c";
            FixedString32 arg3 = "d";
            FixedString32 arg4 = "e";
            FixedString32 arg5 = "f";
            FixedString32 arg6 = "g";
            FixedString32 arg7 = "h";
            FixedString32 arg8 = "i";
            aa.AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            Assert.AreEqual("a b c d e f g h i", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }


        [Test]
        public void HeapStringFormatExtension10Params()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Junk();
            FixedString128 format = "{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}";
            FixedString32 arg0 = "a";
            FixedString32 arg1 = "b";
            FixedString32 arg2 = "c";
            FixedString32 arg3 = "d";
            FixedString32 arg4 = "e";
            FixedString32 arg5 = "f";
            FixedString32 arg6 = "g";
            FixedString32 arg7 = "h";
            FixedString32 arg8 = "i";
            FixedString32 arg9 = "j";
            aa.AppendFormat(format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            Assert.AreEqual("a b c d e f g h i j", aa);
            aa.AssertNullTerminated();
            aa.Dispose();
        }

        [Test]
        public void HeapStringAppendGrows()
        {
            HeapString aa = new HeapString(1, Allocator.Temp);
            var origCapacity = aa.Capacity;
            for (int i = 0; i < origCapacity; ++i)
                aa.Append('a');
            Assert.AreEqual(origCapacity, aa.Capacity);
            aa.Append('b');
            Assert.GreaterOrEqual(aa.Capacity, origCapacity);
            Assert.AreEqual(new String('a', origCapacity) + "b", aa.ToString());
            aa.Dispose();
        }

        [Test]
        public void HeapStringAppendString()
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Append("aa");
            Assert.AreEqual("aa", aa.ToString());
            aa.Append("bb");
            Assert.AreEqual("aabb", aa.ToString());
            aa.Dispose();
        }


        [TestCase("Antidisestablishmentarianism")]
        [TestCase("??????????????????????????????")]
        public void HeapStringCopyFromBytesWorks(String a)
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Junk();
            var utf8 = Encoding.UTF8.GetBytes(a);
            unsafe
            {
                fixed (byte* b = utf8)
                    aa.Append(b, (ushort) utf8.Length);
            }

            Assert.AreEqual(a, aa.ToString());
            aa.AssertNullTerminated();

            aa.Append("tail");
            Assert.AreEqual(a + "tail", aa.ToString());
            aa.AssertNullTerminated();

            aa.Dispose();
        }

        [TestCase("red")]
        [TestCase("??????", TestName = "{m}(Chinese-Red)")]
        [TestCase("George Washington")]
        [TestCase("????????????", TestName = "{m}(HarukiMurakami)")]
        public void HeapStringToStringWorks(String a)
        {
            HeapString aa = new HeapString(4, Allocator.Temp);
            aa.Append(new FixedString128(a));
            Assert.AreEqual(a, aa.ToString());
            aa.AssertNullTerminated();
            aa.Dispose();
        }

        [TestCase("monkey", "monkey")]
        [TestCase("yellow", "green")]
        [TestCase("violet", "??????", TestName = "{m}(Violet-Chinese-Red")]
        [TestCase("??????", "??????", TestName = "{m}(Chinese-Green-Blue")]
        [TestCase("?????????", "????????????", TestName = "{m}(Chinese-Indigo-Violet")]
        [TestCase("James Monroe", "John Quincy Adams")]
        [TestCase("Andrew Jackson", "????????????", TestName = "{m}(AndrewJackson-HarukiMurakami")]
        [TestCase("?????? ?????????", "???????????????", TestName = "{m}(MishimaYukio-YoshimotoBanana")]
        public void HeapStringEqualsWorks(String a, String b)
        {
            HeapString aa = new HeapString(new FixedString128(a), Allocator.Temp);
            HeapString bb = new HeapString(new FixedString128(b), Allocator.Temp);
            Assert.AreEqual(aa.Equals(bb), a.Equals(b));
            aa.AssertNullTerminated();
            bb.AssertNullTerminated();
            aa.Dispose();
            bb.Dispose();
        }

        [Test]
        public void HeapStringForEach()
        {
            HeapString actual = new HeapString("A????Z????", Allocator.Temp);
            FixedList32<int> expected = default;
            expected.Add('A');
            expected.Add(0x1F315);
            expected.Add('Z');
            expected.Add(0x1F311);
            int index = 0;
            foreach (var rune in actual)
            {
                Assert.AreEqual(expected[index], rune.value);
                ++index;
            }

            actual.Dispose();
        }

        [Test]
        public void HeapStringIndexOf()
        {
            HeapString a = new HeapString("bookkeeper bookkeeper", Allocator.Temp);
            HeapString b = new HeapString("ookkee", Allocator.Temp);
            Assert.AreEqual(1, a.IndexOf(b));
            Assert.AreEqual(-1, b.IndexOf(a));
            a.Dispose();
            b.Dispose();
        }

        [Test]
        public void HeapStringLastIndexOf()
        {
            HeapString a = new HeapString("bookkeeper bookkeeper", Allocator.Temp);
            HeapString b = new HeapString("ookkee", Allocator.Temp);
            Assert.AreEqual(12, a.LastIndexOf(b));
            Assert.AreEqual(-1, b.LastIndexOf(a));
            a.Dispose();
            b.Dispose();
        }

        [Test]
        public void HeapStringContains()
        {
            HeapString a = new HeapString("bookkeeper", Allocator.Temp);
            HeapString b = new HeapString("ookkee", Allocator.Temp);
            Assert.AreEqual(true, a.Contains(b));
            a.Dispose();
            b.Dispose();
        }

        [Test]
        public void HeapStringComparisons()
        {
            HeapString a = new HeapString("apple", Allocator.Temp);
            HeapString b = new HeapString("banana", Allocator.Temp);
            Assert.AreEqual(false, a.Equals(b));
            Assert.AreEqual(true, !b.Equals(a));
            a.Dispose();
            b.Dispose();
        }
    }
}
#endif
