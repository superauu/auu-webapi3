using Auu.Framework.Common;
using Xunit;

namespace Auu.UnitTest
{
    public class ZipTest
    {
        [Fact]
        public void ZipTest1()
        {
            var teststr = "中文123abc";
            var t = Zip.GZipCompressString(teststr);
            var t2 = Zip.GZipDecompressString(t);
            Assert.Equal(t2, teststr);

            t = Zip.GZipCompressString("");
            Assert.Equal("", t);
            t2 = Zip.GZipDecompressString("");
            Assert.Equal("", t2);

            t = Zip.GZipCompressString(null);
            Assert.Equal("", t);
            t2 = Zip.GZipDecompressString(null);
            Assert.Equal("", t2);
        }
    }
}