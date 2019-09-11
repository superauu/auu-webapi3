using Auu.Framework.Common;
using Xunit;

namespace Auu.UnitTest
{
    public class EncryptTest
    {
        [Fact]
        public void TestHmacSha1()
        {
            Assert.Equal("kRA2cnpJVacIhDMzXnoNZG9tDCI=",
                Encrypt.Sha1(
                    "GET&%2F&AccessKeyId%3Dtestid%26Action%3DCreateUser%26Format%3DJSON%26SignatureMethod%3DHMAC-SHA1%26SignatureNonce%3D6a6e0ca6-4557-11e5-86a2-b8e8563dc8d2%26SignatureVersion%3D1.0%26Timestamp%3D2015-08-18T03%253A15%253A45Z%26UserName%3Dtest%26Version%3D2015-05-01",
                    "testsecret&"));
            Assert.Equal("", Encrypt.Sha1("", "bbb"));
        }

        [Fact]
        public void TestMd5()
        {
            Assert.Equal("0CC175B9C0F1B6A831C399E269772661", Encrypt.Md5("a"));
            Assert.Equal("", Encrypt.Md5(""));
            Assert.Equal("7215EE9C7D9DC229D2921A40E899EC5F", Encrypt.Md5(" "));
            Assert.Equal("8A97EE1FCDDC24870FB66B4B58C41214", Encrypt.Md5("汉字"));
            Assert.Equal("50D98D0E94B277F2F4248C1FCABDFA55", Encrypt.Md5("normal string"));
        }

        [Fact]
        public void TestSha1()
        {
            Assert.Equal("86f7e437faa5a7fce15d1ddcb9eaeaea377667b8".ToUpper(), Encrypt.Sha1("a"));
            Assert.Equal("", Encrypt.Sha1(""));
            Assert.Equal("b858cb282617fb0956d960215c8e84d1ccf909c6".ToUpper(), Encrypt.Sha1(" "));
            Assert.Equal("c06ce2d7fdeda6ff7629156bee66bf4d818ab397".ToUpper(), Encrypt.Sha1("汉字"));
            Assert.Equal("b37363c346bbed7140fd3a4429a0d74afe18a0d1".ToUpper(), Encrypt.Sha1("normal string"));
        }

        [Fact]
        public void TestSha256()
        {
            Assert.Equal("ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb".ToUpper(),
                Encrypt.Sha256("a"));
            Assert.Equal("", Encrypt.Sha256(""));
            Assert.Equal("36a9e7f1c95b82ffb99743e0c5c4ce95d83c9a430aac59f84ef3cbfab6145068".ToUpper(),
                Encrypt.Sha256(" "));
            Assert.Equal("00e5d5601ce310d84ec2875e28c826f7f4c0a473be7fd53cf50e47f1542db4ea".ToUpper(),
                Encrypt.Sha256("汉字"));
            Assert.Equal("e27d2daca8079b7c79beeb851ade57e887dc43a4c76a7f53c4327a09dc358cfe".ToUpper(),
                Encrypt.Sha256("normal string"));
        }

        [Fact]
        public void TestUrlDecode()
        {
            Assert.Equal("kRA2cnpJVacIhDMzXnoNZG9tDCI=", Encrypt.UrlDecode("kRA2cnpJVacIhDMzXnoNZG9tDCI%3D"));
            Assert.Equal("", Encrypt.UrlDecode(""));
        }

        [Fact]
        public void TestUrlEncode()
        {
            Assert.Equal("kRA2cnpJVacIhDMzXnoNZG9tDCI%3D", Encrypt.UrlEncode("kRA2cnpJVacIhDMzXnoNZG9tDCI="));
            Assert.Equal("", Encrypt.UrlEncode(""));
        }
    }
}