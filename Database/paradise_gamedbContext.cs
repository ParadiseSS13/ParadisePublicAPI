using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParadisePublicAPI.Database
{
    public partial class paradise_gamedbContext : DbContext
    {
        public paradise_gamedbContext()
        {
        }

        public paradise_gamedbContext(DbContextOptions<paradise_gamedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<AdminLog> AdminLogs { get; set; } = null!;
        public virtual DbSet<Ban> Bans { get; set; } = null!;
        public virtual DbSet<Changelog> Changelogs { get; set; } = null!;
        public virtual DbSet<Character> Characters { get; set; } = null!;
        public virtual DbSet<ConnectionLog> ConnectionLogs { get; set; } = null!;
        public virtual DbSet<Customuseritem> Customuseritems { get; set; } = null!;
        public virtual DbSet<Death> Deaths { get; set; } = null!;
        public virtual DbSet<Donator> Donators { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<InstanceDataCache> InstanceDataCaches { get; set; } = null!;
        public virtual DbSet<Ip2group> Ip2groups { get; set; } = null!;
        public virtual DbSet<Ipintel> Ipintels { get; set; } = null!;
        public virtual DbSet<Karma> Karmas { get; set; } = null!;
        public virtual DbSet<Karmatotal> Karmatotals { get; set; } = null!;
        public virtual DbSet<LegacyPopulation> LegacyPopulations { get; set; } = null!;
        public virtual DbSet<Library> Libraries { get; set; } = null!;
        public virtual DbSet<Memo> Memos { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<OauthToken> OauthTokens { get; set; } = null!;
        public virtual DbSet<PaiSafe> PaiSaves { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<PlaytimeHistory> PlaytimeHistories { get; set; } = null!;
        public virtual DbSet<Privacy> Privacies { get; set; } = null!;
        public virtual DbSet<Round> Rounds { get; set; } = null!;
        public virtual DbSet<VpnWhitelist> VpnWhitelists { get; set; } = null!;
        public virtual DbSet<Watch> Watches { get; set; } = null!;
        public virtual DbSet<Whitelist> Whitelists { get; set; } = null!;
        public virtual DbSet<_2faSecret> _2faSecrets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Ckey, "ckey");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AdminRank)
                    .HasMaxLength(32)
                    .HasColumnName("admin_rank")
                    .HasDefaultValueSql("'Administrator'")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Flags)
                    .HasColumnType("int(16)")
                    .HasColumnName("flags");

                entity.Property(e => e.Level)
                    .HasColumnType("int(2)")
                    .HasColumnName("level");
            });

            modelBuilder.Entity<AdminLog>(entity =>
            {
                entity.ToTable("admin_log");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Adminckey, "adminckey");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Adminckey)
                    .HasMaxLength(32)
                    .HasColumnName("adminckey")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Adminip)
                    .HasMaxLength(18)
                    .HasColumnName("adminip")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.Log)
                    .HasColumnType("mediumtext")
                    .HasColumnName("log")
                    .UseCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Ban>(entity =>
            {
                entity.ToTable("ban");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Ckey, "ckey");

                entity.HasIndex(e => e.Computerid, "computerid");

                entity.HasIndex(e => e.Ip, "ip");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ACkey)
                    .HasMaxLength(32)
                    .HasColumnName("a_ckey");

                entity.Property(e => e.AComputerid)
                    .HasMaxLength(32)
                    .HasColumnName("a_computerid");

                entity.Property(e => e.AIp)
                    .HasMaxLength(32)
                    .HasColumnName("a_ip");

                entity.Property(e => e.Adminwho)
                    .HasColumnType("mediumtext")
                    .HasColumnName("adminwho");

                entity.Property(e => e.BanRoundId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ban_round_id");

                entity.Property(e => e.Bantime)
                    .HasColumnType("datetime")
                    .HasColumnName("bantime");

                entity.Property(e => e.Bantype)
                    .HasMaxLength(32)
                    .HasColumnName("bantype");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Computerid)
                    .HasMaxLength(32)
                    .HasColumnName("computerid");

                entity.Property(e => e.Duration)
                    .HasColumnType("int(11)")
                    .HasColumnName("duration");

                entity.Property(e => e.Edits)
                    .HasColumnType("mediumtext")
                    .HasColumnName("edits");

                entity.Property(e => e.ExpirationTime)
                    .HasColumnType("datetime")
                    .HasColumnName("expiration_time");

                entity.Property(e => e.Ip)
                    .HasMaxLength(32)
                    .HasColumnName("ip");

                entity.Property(e => e.Job)
                    .HasMaxLength(32)
                    .HasColumnName("job");

                entity.Property(e => e.Reason)
                    .HasColumnType("mediumtext")
                    .HasColumnName("reason");

                entity.Property(e => e.Rounds)
                    .HasColumnType("int(11)")
                    .HasColumnName("rounds");

                entity.Property(e => e.ServerId)
                    .HasMaxLength(50)
                    .HasColumnName("server_id")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Serverip)
                    .HasMaxLength(32)
                    .HasColumnName("serverip");

                entity.Property(e => e.Unbanned).HasColumnName("unbanned");

                entity.Property(e => e.UnbannedCkey)
                    .HasMaxLength(32)
                    .HasColumnName("unbanned_ckey");

                entity.Property(e => e.UnbannedComputerid)
                    .HasMaxLength(32)
                    .HasColumnName("unbanned_computerid");

                entity.Property(e => e.UnbannedDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("unbanned_datetime");

                entity.Property(e => e.UnbannedIp)
                    .HasMaxLength(32)
                    .HasColumnName("unbanned_ip");

                entity.Property(e => e.UnbannedRoundId)
                    .HasColumnType("int(11)")
                    .HasColumnName("unbanned_round_id");

                entity.Property(e => e.Who)
                    .HasColumnType("mediumtext")
                    .HasColumnName("who");
            });

            modelBuilder.Entity<Changelog>(entity =>
            {
                entity.ToTable("changelog");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(32)
                    .HasColumnName("author");

                entity.Property(e => e.ClEntry)
                    .HasColumnType("text")
                    .HasColumnName("cl_entry");

                entity.Property(e => e.ClType)
                    .HasColumnType("enum('FIX','WIP','TWEAK','SOUNDADD','SOUNDDEL','CODEADD','CODEDEL','IMAGEADD','IMAGEDEL','SPELLCHECK','EXPERIMENT')")
                    .HasColumnName("cl_type");

                entity.Property(e => e.DateMerged)
                    .HasColumnType("timestamp")
                    .HasColumnName("date_merged")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.PrNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("pr_number");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("characters");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Ckey, "ckey");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Age)
                    .HasColumnType("smallint(4)")
                    .HasColumnName("age");

                entity.Property(e => e.AltHeadName)
                    .HasMaxLength(45)
                    .HasColumnName("alt_head_name");

                entity.Property(e => e.AlternateOption)
                    .HasColumnType("smallint(4)")
                    .HasColumnName("alternate_option");

                entity.Property(e => e.Autohiss).HasColumnName("autohiss");

                entity.Property(e => e.BType)
                    .HasMaxLength(45)
                    .HasColumnName("b_type");

                entity.Property(e => e.Backbag).HasColumnName("backbag");

                entity.Property(e => e.BodyAccessory).HasColumnName("body_accessory");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Disabilities)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("disabilities");

                entity.Property(e => e.EyeColour)
                    .HasMaxLength(7)
                    .HasColumnName("eye_colour")
                    .HasDefaultValueSql("'#000000'");

                entity.Property(e => e.FacialHairColour)
                    .HasMaxLength(7)
                    .HasColumnName("facial_hair_colour")
                    .HasDefaultValueSql("'#000000'");

                entity.Property(e => e.FacialStyleName)
                    .HasMaxLength(45)
                    .HasColumnName("facial_style_name");

                entity.Property(e => e.FlavorText).HasColumnName("flavor_text");

                entity.Property(e => e.Gear).HasColumnName("gear");

                entity.Property(e => e.GenRecord).HasColumnName("gen_record");

                entity.Property(e => e.Gender)
                    .HasMaxLength(11)
                    .HasColumnName("gender");

                entity.Property(e => e.HairColour)
                    .HasMaxLength(7)
                    .HasColumnName("hair_colour")
                    .HasDefaultValueSql("'#000000'");

                entity.Property(e => e.HairGradient)
                    .HasMaxLength(45)
                    .HasColumnName("hair_gradient");

                entity.Property(e => e.HairGradientAlpha)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("hair_gradient_alpha")
                    .HasDefaultValueSql("'255'");

                entity.Property(e => e.HairGradientColour)
                    .HasMaxLength(7)
                    .HasColumnName("hair_gradient_colour")
                    .HasDefaultValueSql("'#000000'");

                entity.Property(e => e.HairGradientOffset)
                    .HasMaxLength(7)
                    .HasColumnName("hair_gradient_offset")
                    .HasDefaultValueSql("'0,0'");

                entity.Property(e => e.HairStyleName)
                    .HasMaxLength(45)
                    .HasColumnName("hair_style_name");

                entity.Property(e => e.HeadAccessoryColour)
                    .HasMaxLength(7)
                    .HasColumnName("head_accessory_colour")
                    .HasDefaultValueSql("'#000000'");

                entity.Property(e => e.HeadAccessoryStyleName)
                    .HasMaxLength(45)
                    .HasColumnName("head_accessory_style_name");

                entity.Property(e => e.JobEngsecHigh)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_engsec_high");

                entity.Property(e => e.JobEngsecLow)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_engsec_low");

                entity.Property(e => e.JobEngsecMed)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_engsec_med");

                entity.Property(e => e.JobKarmaHigh)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_karma_high");

                entity.Property(e => e.JobKarmaLow)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_karma_low");

                entity.Property(e => e.JobKarmaMed)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_karma_med");

                entity.Property(e => e.JobMedsciHigh)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_medsci_high");

                entity.Property(e => e.JobMedsciLow)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_medsci_low");

                entity.Property(e => e.JobMedsciMed)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_medsci_med");

                entity.Property(e => e.JobSupportHigh)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_support_high");

                entity.Property(e => e.JobSupportLow)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_support_low");

                entity.Property(e => e.JobSupportMed)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("job_support_med");

                entity.Property(e => e.Language)
                    .HasMaxLength(45)
                    .HasColumnName("language");

                entity.Property(e => e.MarkingColours)
                    .HasMaxLength(255)
                    .HasColumnName("marking_colours")
                    .HasDefaultValueSql("'head=%23000000&body=%23000000&tail=%23000000'");

                entity.Property(e => e.MarkingStyles)
                    .HasMaxLength(255)
                    .HasColumnName("marking_styles")
                    .HasDefaultValueSql("'head=None&body=None&tail=None'");

                entity.Property(e => e.MedRecord).HasColumnName("med_record");

                entity.Property(e => e.NameIsAlwaysRandom).HasColumnName("name_is_always_random");

                entity.Property(e => e.NanotrasenRelation)
                    .HasMaxLength(45)
                    .HasColumnName("nanotrasen_relation");

                entity.Property(e => e.OocNotes).HasColumnName("OOC_Notes");

                entity.Property(e => e.OrganData).HasColumnName("organ_data");

                entity.Property(e => e.PlayerAltTitles).HasColumnName("player_alt_titles");

                entity.Property(e => e.RealName)
                    .HasMaxLength(55)
                    .HasColumnName("real_name");

                entity.Property(e => e.RlimbData).HasColumnName("rlimb_data");

                entity.Property(e => e.SecRecord).HasColumnName("sec_record");

                entity.Property(e => e.SecondaryFacialHairColour)
                    .HasMaxLength(7)
                    .HasColumnName("secondary_facial_hair_colour")
                    .HasDefaultValueSql("'#000000'");

                entity.Property(e => e.SecondaryHairColour)
                    .HasMaxLength(7)
                    .HasColumnName("secondary_hair_colour")
                    .HasDefaultValueSql("'#000000'");

                entity.Property(e => e.SkinColour)
                    .HasMaxLength(7)
                    .HasColumnName("skin_colour")
                    .HasDefaultValueSql("'#000000'");

                entity.Property(e => e.SkinTone)
                    .HasColumnType("smallint(4)")
                    .HasColumnName("skin_tone");

                entity.Property(e => e.Slot)
                    .HasColumnType("int(2)")
                    .HasColumnName("slot");

                entity.Property(e => e.Socks).HasColumnName("socks");

                entity.Property(e => e.Species)
                    .HasMaxLength(45)
                    .HasColumnName("species");

                entity.Property(e => e.Speciesprefs)
                    .HasColumnType("int(1)")
                    .HasColumnName("speciesprefs");

                entity.Property(e => e.Undershirt).HasColumnName("undershirt");

                entity.Property(e => e.Underwear).HasColumnName("underwear");
            });

            modelBuilder.Entity<ConnectionLog>(entity =>
            {
                entity.ToTable("connection_log");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Ckey, "ckey");

                entity.HasIndex(e => e.Computerid, "computerid");

                entity.HasIndex(e => e.Ip, "ip");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Computerid)
                    .HasMaxLength(32)
                    .HasColumnName("computerid");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.Ip)
                    .HasMaxLength(32)
                    .HasColumnName("ip");

                entity.Property(e => e.Result)
                    .HasColumnType("enum('ESTABLISHED','DROPPED - IPINTEL','DROPPED - BANNED','DROPPED - INVALID')")
                    .HasColumnName("result")
                    .HasDefaultValueSql("'ESTABLISHED'");

                entity.Property(e => e.ServerId)
                    .HasMaxLength(50)
                    .HasColumnName("server_id");
            });

            modelBuilder.Entity<Customuseritem>(entity =>
            {
                entity.ToTable("customuseritems");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.CuiCkey, "cuiCKey");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CuiCkey)
                    .HasMaxLength(36)
                    .HasColumnName("cuiCKey");

                entity.Property(e => e.CuiDescription)
                    .HasColumnType("text")
                    .HasColumnName("cuiDescription");

                entity.Property(e => e.CuiItemName)
                    .HasColumnType("text")
                    .HasColumnName("cuiItemName");

                entity.Property(e => e.CuiJobMask)
                    .HasColumnType("text")
                    .HasColumnName("cuiJobMask");

                entity.Property(e => e.CuiPath)
                    .HasMaxLength(255)
                    .HasColumnName("cuiPath");

                entity.Property(e => e.CuiPropAdjust)
                    .HasColumnType("text")
                    .HasColumnName("cuiPropAdjust");

                entity.Property(e => e.CuiRealName)
                    .HasMaxLength(60)
                    .HasColumnName("cuiRealName");

                entity.Property(e => e.CuiReason)
                    .HasColumnType("text")
                    .HasColumnName("cuiReason");
            });

            modelBuilder.Entity<Death>(entity =>
            {
                entity.ToTable("death");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Brainloss)
                    .HasColumnType("int(11)")
                    .HasColumnName("brainloss");

                entity.Property(e => e.Bruteloss)
                    .HasColumnType("int(11)")
                    .HasColumnName("bruteloss");

                entity.Property(e => e.Byondkey)
                    .HasColumnType("text")
                    .HasColumnName("byondkey");

                entity.Property(e => e.Coord)
                    .HasColumnType("text")
                    .HasColumnName("coord")
                    .HasComment("X, Y, Z POD");

                entity.Property(e => e.Fireloss)
                    .HasColumnType("int(11)")
                    .HasColumnName("fireloss");

                entity.Property(e => e.Gender)
                    .HasColumnType("text")
                    .HasColumnName("gender");

                entity.Property(e => e.Job)
                    .HasColumnType("text")
                    .HasColumnName("job");

                entity.Property(e => e.Lakey)
                    .HasColumnType("text")
                    .HasColumnName("lakey")
                    .HasComment("Last attacker key");

                entity.Property(e => e.Laname)
                    .HasColumnType("text")
                    .HasColumnName("laname")
                    .HasComment("Last attacker name");

                entity.Property(e => e.Name)
                    .HasColumnType("text")
                    .HasColumnName("name");

                entity.Property(e => e.Oxyloss)
                    .HasColumnType("int(11)")
                    .HasColumnName("oxyloss");

                entity.Property(e => e.Pod)
                    .HasColumnType("text")
                    .HasColumnName("pod")
                    .HasComment("Place of death");

                entity.Property(e => e.ServerId)
                    .HasColumnType("text")
                    .HasColumnName("server_id");

                entity.Property(e => e.Special)
                    .HasColumnType("text")
                    .HasColumnName("special");

                entity.Property(e => e.Tod)
                    .HasColumnType("datetime")
                    .HasColumnName("tod")
                    .HasComment("Time of death");
            });

            modelBuilder.Entity<Donator>(entity =>
            {
                entity.HasKey(e => e.PatreonName)
                    .HasName("PRIMARY");

                entity.ToTable("donators");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Ckey, "ckey");

                entity.Property(e => e.PatreonName)
                    .HasMaxLength(32)
                    .HasColumnName("patreon_name");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey")
                    .HasComment("Manual Field");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.Tier)
                    .HasColumnType("int(2)")
                    .HasColumnName("tier");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.Json).HasColumnName("json");

                entity.Property(e => e.KeyName)
                    .HasMaxLength(32)
                    .HasColumnName("key_name");

                entity.Property(e => e.KeyType)
                    .HasColumnType("enum('text','amount','tally','nested tally','associative')")
                    .HasColumnName("key_type");

                entity.Property(e => e.RoundId)
                    .HasColumnType("int(8)")
                    .HasColumnName("round_id");

                entity.Property(e => e.Version)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("version");
            });

            modelBuilder.Entity<InstanceDataCache>(entity =>
            {
                entity.HasKey(e => new { e.ServerId, e.KeyName })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("instance_data_cache");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.ServerId)
                    .HasMaxLength(50)
                    .HasColumnName("server_id");

                entity.Property(e => e.KeyName)
                    .HasMaxLength(50)
                    .HasColumnName("key_name");

                entity.Property(e => e.KeyValue)
                    .HasMaxLength(12345)
                    .HasColumnName("key_value");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("current_timestamp()");
            });

            modelBuilder.Entity<Ip2group>(entity =>
            {
                entity.HasKey(e => e.Ip)
                    .HasName("PRIMARY");

                entity.ToTable("ip2group");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Groupstr, "groupstr");

                entity.Property(e => e.Ip)
                    .HasMaxLength(18)
                    .HasColumnName("ip")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Groupstr)
                    .HasMaxLength(32)
                    .HasColumnName("groupstr")
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Ipintel>(entity =>
            {
                entity.HasKey(e => e.Ip)
                    .HasName("PRIMARY");

                entity.ToTable("ipintel");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Ip)
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever()
                    .HasColumnName("ip");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("date")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Intel).HasColumnName("intel");
            });

            modelBuilder.Entity<Karma>(entity =>
            {
                entity.ToTable("karma");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Isnegative).HasColumnName("isnegative");

                entity.Property(e => e.Receiverkey)
                    .HasColumnType("text")
                    .HasColumnName("receiverkey");

                entity.Property(e => e.Receivername)
                    .HasColumnType("text")
                    .HasColumnName("receivername");

                entity.Property(e => e.Receiverrole)
                    .HasColumnType("text")
                    .HasColumnName("receiverrole");

                entity.Property(e => e.Receiverspecial)
                    .HasColumnType("text")
                    .HasColumnName("receiverspecial");

                entity.Property(e => e.ServerId)
                    .HasColumnType("text")
                    .HasColumnName("server_id");

                entity.Property(e => e.Spenderip)
                    .HasColumnType("text")
                    .HasColumnName("spenderip");

                entity.Property(e => e.Spenderkey)
                    .HasColumnType("text")
                    .HasColumnName("spenderkey");

                entity.Property(e => e.Spendername)
                    .HasColumnType("text")
                    .HasColumnName("spendername");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");
            });

            modelBuilder.Entity<Karmatotal>(entity =>
            {
                entity.ToTable("karmatotals");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Byondkey, "byondkey");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Byondkey)
                    .HasMaxLength(30)
                    .HasColumnName("byondkey");

                entity.Property(e => e.Karma)
                    .HasColumnType("int(11)")
                    .HasColumnName("karma");

                entity.Property(e => e.Karmaspent)
                    .HasColumnType("int(11)")
                    .HasColumnName("karmaspent");
            });

            modelBuilder.Entity<LegacyPopulation>(entity =>
            {
                entity.ToTable("legacy_population");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Admincount)
                    .HasColumnType("int(11)")
                    .HasColumnName("admincount");

                entity.Property(e => e.Playercount)
                    .HasColumnType("int(11)")
                    .HasColumnName("playercount");

                entity.Property(e => e.ServerId)
                    .HasMaxLength(50)
                    .HasColumnName("server_id");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.ToTable("library");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Ckey, "ckey");

                entity.HasIndex(e => e.Flagged, "flagged");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasColumnType("mediumtext")
                    .HasColumnName("author");

                entity.Property(e => e.Category)
                    .HasColumnType("mediumtext")
                    .HasColumnName("category");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Content)
                    .HasColumnType("mediumtext")
                    .HasColumnName("content");

                entity.Property(e => e.Flagged)
                    .HasColumnType("int(11)")
                    .HasColumnName("flagged");

                entity.Property(e => e.Title)
                    .HasColumnType("mediumtext")
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Memo>(entity =>
            {
                entity.HasKey(e => e.Ckey)
                    .HasName("PRIMARY");

                entity.ToTable("memo");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Edits)
                    .HasColumnType("text")
                    .HasColumnName("edits");

                entity.Property(e => e.LastEditor)
                    .HasMaxLength(32)
                    .HasColumnName("last_editor");

                entity.Property(e => e.Memotext)
                    .HasColumnType("text")
                    .HasColumnName("memotext");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("notes");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Ckey, "ckey");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Adminckey)
                    .HasMaxLength(32)
                    .HasColumnName("adminckey");

                entity.Property(e => e.Automated)
                    .HasColumnType("tinyint(3) unsigned")
                    .HasColumnName("automated")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.CrewPlaytime)
                    .HasColumnType("mediumint(8) unsigned")
                    .HasColumnName("crew_playtime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Edits)
                    .HasColumnType("text")
                    .HasColumnName("edits");

                entity.Property(e => e.LastEditor)
                    .HasMaxLength(32)
                    .HasColumnName("last_editor");

                entity.Property(e => e.Notetext)
                    .HasColumnType("text")
                    .HasColumnName("notetext");

                entity.Property(e => e.RoundId)
                    .HasColumnType("int(11)")
                    .HasColumnName("round_id");

                entity.Property(e => e.Server)
                    .HasMaxLength(50)
                    .HasColumnName("server");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<OauthToken>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PRIMARY");

                entity.ToTable("oauth_tokens");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Ckey, "ckey");

                entity.Property(e => e.Token)
                    .HasMaxLength(32)
                    .HasColumnName("token");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");
            });

            modelBuilder.Entity<PaiSafe>(entity =>
            {
                entity.ToTable("pai_saves");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Ckey, "ckey")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(50)
                    .HasColumnName("ckey");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.OocComments).HasColumnName("ooc_comments");

                entity.Property(e => e.PaiName).HasColumnName("pai_name");

                entity.Property(e => e.PreferredRole).HasColumnName("preferred_role");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("player");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Ckey, "ckey")
                    .IsUnique();

                entity.HasIndex(e => e.Computerid, "computerid");

                entity.HasIndex(e => e.Fuid, "fuid");

                entity.HasIndex(e => e.Fupdate, "fupdate");

                entity.HasIndex(e => e.Ip, "ip");

                entity.HasIndex(e => e.Lastseen, "lastseen");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Atklog)
                    .HasColumnType("smallint(4)")
                    .HasColumnName("atklog")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BeRole).HasColumnName("be_role");

                entity.Property(e => e.ByondDate).HasColumnName("byond_date");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Clientfps)
                    .HasColumnType("smallint(4)")
                    .HasColumnName("clientfps")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Computerid)
                    .HasMaxLength(32)
                    .HasColumnName("computerid");

                entity.Property(e => e.DefaultSlot)
                    .HasColumnType("smallint(4)")
                    .HasColumnName("default_slot")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Exp).HasColumnName("exp");

                entity.Property(e => e.Firstseen)
                    .HasColumnType("datetime")
                    .HasColumnName("firstseen");

                entity.Property(e => e.Fuid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("fuid");

                entity.Property(e => e.Fupdate)
                    .HasColumnType("smallint(4)")
                    .HasColumnName("fupdate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ip)
                    .HasMaxLength(18)
                    .HasColumnName("ip");

                entity.Property(e => e.Lastadminrank)
                    .HasMaxLength(32)
                    .HasColumnName("lastadminrank")
                    .HasDefaultValueSql("'Player'");

                entity.Property(e => e.Lastchangelog)
                    .HasMaxLength(32)
                    .HasColumnName("lastchangelog")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lastseen)
                    .HasColumnType("datetime")
                    .HasColumnName("lastseen");

                entity.Property(e => e.Ooccolor)
                    .HasMaxLength(7)
                    .HasColumnName("ooccolor")
                    .HasDefaultValueSql("'#b82e00'");

                entity.Property(e => e.Parallax)
                    .HasColumnName("parallax")
                    .HasDefaultValueSql("'8'");

                entity.Property(e => e.Sound)
                    .HasColumnType("mediumint(8)")
                    .HasColumnName("sound")
                    .HasDefaultValueSql("'31'");

                entity.Property(e => e.Toggles)
                    .HasColumnType("int(11)")
                    .HasColumnName("toggles");

                entity.Property(e => e.Toggles2)
                    .HasColumnType("int(11)")
                    .HasColumnName("toggles_2")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UiStyle)
                    .HasMaxLength(10)
                    .HasColumnName("UI_style")
                    .HasDefaultValueSql("'Midnight'");

                entity.Property(e => e.UiStyleAlpha)
                    .HasColumnType("smallint(4)")
                    .HasColumnName("UI_style_alpha")
                    .HasDefaultValueSql("'255'");

                entity.Property(e => e.UiStyleColor)
                    .HasMaxLength(7)
                    .HasColumnName("UI_style_color")
                    .HasDefaultValueSql("'#ffffff'");

                entity.Property(e => e.VolumeMixer).HasColumnName("volume_mixer");

                entity.Property(e => e._2faStatus)
                    .HasColumnType("enum('DISABLED','ENABLED_IP','ENABLED_ALWAYS')")
                    .HasColumnName("2fa_status")
                    .HasDefaultValueSql("'DISABLED'")
                    .UseCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<PlaytimeHistory>(entity =>
            {
                entity.HasKey(e => new { e.Ckey, e.Date })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("playtime_history");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.TimeGhost)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("time_ghost");

                entity.Property(e => e.TimeLiving)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("time_living");
            });

            modelBuilder.Entity<Privacy>(entity =>
            {
                entity.HasKey(e => e.Ckey)
                    .HasName("PRIMARY");

                entity.ToTable("privacy");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Consent)
                    .HasColumnType("bit(1)")
                    .HasColumnName("consent");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");
            });

            modelBuilder.Entity<Round>(entity =>
            {
                entity.ToTable("round");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CommitHash)
                    .HasMaxLength(40)
                    .HasColumnName("commit_hash")
                    .IsFixedLength();

                entity.Property(e => e.EndDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_datetime");

                entity.Property(e => e.EndState)
                    .HasMaxLength(64)
                    .HasColumnName("end_state");

                entity.Property(e => e.GameMode)
                    .HasMaxLength(32)
                    .HasColumnName("game_mode");

                entity.Property(e => e.GameModeResult)
                    .HasMaxLength(64)
                    .HasColumnName("game_mode_result");

                entity.Property(e => e.InitializeDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("initialize_datetime");

                entity.Property(e => e.MapName)
                    .HasMaxLength(32)
                    .HasColumnName("map_name");

                entity.Property(e => e.ServerId)
                    .HasMaxLength(50)
                    .HasColumnName("server_id");

                entity.Property(e => e.ServerIp)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("server_ip");

                entity.Property(e => e.ServerPort)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("server_port");

                entity.Property(e => e.ShutdownDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("shutdown_datetime");

                entity.Property(e => e.ShuttleName)
                    .HasMaxLength(64)
                    .HasColumnName("shuttle_name");

                entity.Property(e => e.StartDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_datetime");

                entity.Property(e => e.StationName)
                    .HasMaxLength(80)
                    .HasColumnName("station_name");
            });

            modelBuilder.Entity<VpnWhitelist>(entity =>
            {
                entity.HasKey(e => e.Ckey)
                    .HasName("PRIMARY");

                entity.ToTable("vpn_whitelist");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Reason)
                    .HasColumnType("text")
                    .HasColumnName("reason");
            });

            modelBuilder.Entity<Watch>(entity =>
            {
                entity.HasKey(e => e.Ckey)
                    .HasName("PRIMARY");

                entity.ToTable("watch");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Adminckey)
                    .HasMaxLength(32)
                    .HasColumnName("adminckey");

                entity.Property(e => e.Edits)
                    .HasColumnType("mediumtext")
                    .HasColumnName("edits");

                entity.Property(e => e.LastEditor)
                    .HasMaxLength(32)
                    .HasColumnName("last_editor");

                entity.Property(e => e.Reason)
                    .HasColumnType("mediumtext")
                    .HasColumnName("reason");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<Whitelist>(entity =>
            {
                entity.ToTable("whitelist");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Ckey, "ckey");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(32)
                    .HasColumnName("ckey");

                entity.Property(e => e.Job)
                    .HasColumnType("mediumtext")
                    .HasColumnName("job");

                entity.Property(e => e.Species)
                    .HasColumnType("mediumtext")
                    .HasColumnName("species");
            });

            modelBuilder.Entity<_2faSecret>(entity =>
            {
                entity.HasKey(e => e.Ckey)
                    .HasName("PRIMARY");

                entity.ToTable("2fa_secrets");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Ckey)
                    .HasMaxLength(50)
                    .HasColumnName("ckey");

                entity.Property(e => e.DateSetup)
                    .HasColumnType("datetime")
                    .HasColumnName("date_setup")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.LastTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_time");

                entity.Property(e => e.Secret)
                    .HasMaxLength(64)
                    .HasColumnName("secret");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
