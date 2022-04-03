using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NzbDrone.Common.Serializer;
using NzbDrone.Core.Datastore.Migration;
using NzbDrone.Core.Test.Framework;

namespace NzbDrone.Core.Test.Datastore.Migration
{
    [TestFixture]
    public class email_multiple_addressesFixture : MigrationTest<email_multiple_addresses>
    {
        [Test]
        public void should_convert_to_list_on_email_lists()
        {
            var db = WithMigrationTestDb(c =>
            {
                c.Insert.IntoTable("Notifications").Row(new
                {
                    OnGrab = true,
                    OnDownload = true,
                    OnUpgrade = true,
                    OnHealthIssue = true,
                    IncludeHealthWarnings = true,
                    OnRename = true,
                    Name = "Gmail Radarr",
                    Implementation = "Email",
                    Tags = "[]",
                    Settings = new EmailSettings173
                    {
                        Server = "smtp.gmail.com",
                        Port = 563,
                        To = "radarr@radarr.video"
                    }.ToJson(),
                    ConfigContract = "EmailSettings"
                });
            });

            var items = db.Query<ProviderDefinition166>("SELECT * FROM \"Notifications\"");

            items.Should().HaveCount(1);
            items.First().Implementation.Should().Be("Email");
            items.First().ConfigContract.Should().Be("EmailSettings");
            items.First().Settings.To.Count().Should().Be(1);
        }
    }

    public class ProviderDefinition166
    {
        public int Id { get; set; }
        public string Implementation { get; set; }
        public string ConfigContract { get; set; }
        public EmailSettings174 Settings { get; set; }
        public string Name { get; set; }
        public bool OnGrab { get; set; }
        public bool OnDownload { get; set; }
        public bool OnUpgrade { get; set; }
        public bool OnRename { get; set; }
        public bool OnHealthIssue { get; set; }
        public bool IncludeHealthWarnings { get; set; }
        public List<int> Tags { get; set; }
    }

    public class EmailSettings173
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

    public class EmailSettings174
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public IEnumerable<string> To { get; set; }
    }
}
