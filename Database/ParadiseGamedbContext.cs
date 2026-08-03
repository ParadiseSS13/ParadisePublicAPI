using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ParadisePublicAPI.Database;

public partial class ParadiseGamedbContext : DbContext
{
    public ParadiseGamedbContext()
    {
    }

    public ParadiseGamedbContext(DbContextOptions<ParadiseGamedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminLog> AdminLogs { get; set; }

    public virtual DbSet<AdminRank> AdminRanks { get; set; }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<BugReport> BugReports { get; set; }

    public virtual DbSet<Changelog> Changelogs { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<ConnectionLog> ConnectionLogs { get; set; }

    public virtual DbSet<Customuseritem> Customuseritems { get; set; }

    public virtual DbSet<Death> Deaths { get; set; }

    public virtual DbSet<Donator> Donators { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<InstanceDataCache> InstanceDataCaches { get; set; }

    public virtual DbSet<Ip2group> Ip2groups { get; set; }

    public virtual DbSet<Ipintel> Ipintels { get; set; }

    public virtual DbSet<JsonDatumSafe> JsonDatumSaves { get; set; }

    public virtual DbSet<LegacyPopulation> LegacyPopulations { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<Memo> Memos { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<OauthToken> OauthTokens { get; set; }

    public virtual DbSet<PaiSafe> PaiSaves { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlaytimeHistory> PlaytimeHistories { get; set; }

    public virtual DbSet<Privacy> Privacies { get; set; }

    public virtual DbSet<Round> Rounds { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<VpnWhitelist> VpnWhitelists { get; set; }

    public virtual DbSet<Watch> Watches { get; set; }

    public virtual DbSet<_2faSecret> _2faSecrets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("admin")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.HasIndex(e => e.Ckey, "ckey");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.DisplayRank)
                .HasMaxLength(32)
                .HasColumnName("display_rank")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.ExtraPermissions)
                .HasColumnType("int(16)")
                .HasColumnName("extra_permissions");
            entity.Property(e => e.PermissionsRank)
                .HasComment("Foreign key for admin_ranks.id")
                .HasColumnType("int(11)")
                .HasColumnName("permissions_rank");
            entity.Property(e => e.RemovedPermissions)
                .HasColumnType("int(16)")
                .HasColumnName("removed_permissions");
        });

        modelBuilder.Entity<AdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("admin_log")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.HasIndex(e => e.Adminckey, "adminckey");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Adminckey)
                .HasMaxLength(32)
                .HasColumnName("adminckey")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Adminip)
                .HasMaxLength(18)
                .HasColumnName("adminip")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.Log)
                .HasColumnType("mediumtext")
                .HasColumnName("log")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<AdminRank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("admin_ranks")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.HasIndex(e => e.Name, "name");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DefaultPermissions)
                .HasColumnType("int(16)")
                .HasColumnName("default_permissions");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .HasColumnName("name")
                .UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ban")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Ckey, "ckey");

            entity.HasIndex(e => e.Computerid, "computerid");

            entity.HasIndex(e => e.Exportable, "exportable");

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
            entity.Property(e => e.Exportable)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("exportable");
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

        modelBuilder.Entity<BugReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("bug_reports")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Submitted, "submitted");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ApproverCkey)
                .HasMaxLength(32)
                .HasColumnName("approver_ckey");
            entity.Property(e => e.AuthorCkey)
                .HasMaxLength(32)
                .HasColumnName("author_ckey");
            entity.Property(e => e.ContentsJson).HasColumnName("contents_json");
            entity.Property(e => e.Filetime)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("filetime");
            entity.Property(e => e.RoundId)
                .HasColumnType("int(11)")
                .HasColumnName("round_id");
            entity.Property(e => e.Submitted)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(2)")
                .HasColumnName("submitted");
            entity.Property(e => e.Title)
                .HasColumnType("mediumtext")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Changelog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("changelog")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(32)
                .HasColumnName("author")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.ClEntry)
                .HasColumnType("text")
                .HasColumnName("cl_entry")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.ClType)
                .HasColumnType("enum('FIX','WIP','TWEAK','SOUNDADD','SOUNDDEL','CODEADD','CODEDEL','IMAGEADD','IMAGEDEL','SPELLCHECK','EXPERIMENT')")
                .HasColumnName("cl_type")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.DateMerged)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("date_merged");
            entity.Property(e => e.PrNumber)
                .HasColumnType("int(11)")
                .HasColumnName("pr_number");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("characters")
                .HasCharSet("utf8mb4")
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
            entity.Property(e => e.BodyType)
                .HasMaxLength(11)
                .HasColumnName("body_type");
            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey");
            entity.Property(e => e.CustomEmotes).HasColumnName("custom_emotes");
            entity.Property(e => e.CyborgBrainType)
                .HasDefaultValueSql("'MMI'")
                .HasColumnType("enum('MMI','Robobrain','Positronic')")
                .HasColumnName("cyborg_brain_type");
            entity.Property(e => e.Disabilities)
                .HasColumnType("mediumint(8)")
                .HasColumnName("disabilities");
            entity.Property(e => e.EyeColour)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("eye_colour");
            entity.Property(e => e.FacialHairColour)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("facial_hair_colour");
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
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("hair_colour");
            entity.Property(e => e.HairGradient)
                .HasMaxLength(45)
                .HasColumnName("hair_gradient");
            entity.Property(e => e.HairGradientAlpha)
                .HasDefaultValueSql("'255'")
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("hair_gradient_alpha");
            entity.Property(e => e.HairGradientColour)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("hair_gradient_colour");
            entity.Property(e => e.HairGradientOffset)
                .HasMaxLength(7)
                .HasDefaultValueSql("'0,0'")
                .HasColumnName("hair_gradient_offset");
            entity.Property(e => e.HairStyleName)
                .HasMaxLength(45)
                .HasColumnName("hair_style_name");
            entity.Property(e => e.HeadAccessoryColour)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("head_accessory_colour");
            entity.Property(e => e.HeadAccessoryStyleName)
                .HasMaxLength(45)
                .HasColumnName("head_accessory_style_name");
            entity.Property(e => e.Height)
                .HasMaxLength(45)
                .HasColumnName("height");
            entity.Property(e => e.JobEngsecHigh)
                .HasColumnType("mediumint(8)")
                .HasColumnName("job_engsec_high");
            entity.Property(e => e.JobEngsecLow)
                .HasColumnType("mediumint(8)")
                .HasColumnName("job_engsec_low");
            entity.Property(e => e.JobEngsecMed)
                .HasColumnType("mediumint(8)")
                .HasColumnName("job_engsec_med");
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
                .HasDefaultValueSql("'head=%23000000&body=%23000000&tail=%23000000'")
                .HasColumnName("marking_colours");
            entity.Property(e => e.MarkingStyles)
                .HasMaxLength(255)
                .HasDefaultValueSql("'head=None&body=None&tail=None'")
                .HasColumnName("marking_styles");
            entity.Property(e => e.MedRecord).HasColumnName("med_record");
            entity.Property(e => e.NameIsAlwaysRandom).HasColumnName("name_is_always_random");
            entity.Property(e => e.NanotrasenRelation)
                .HasMaxLength(45)
                .HasColumnName("nanotrasen_relation");
            entity.Property(e => e.OocNotes).HasColumnName("OOC_Notes");
            entity.Property(e => e.OrganData).HasColumnName("organ_data");
            entity.Property(e => e.PdaRingtone)
                .HasMaxLength(16)
                .HasColumnName("pda_ringtone")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Physique)
                .HasMaxLength(45)
                .HasColumnName("physique");
            entity.Property(e => e.PlayerAltTitles).HasColumnName("player_alt_titles");
            entity.Property(e => e.Quirks).HasColumnName("quirks");
            entity.Property(e => e.RealName)
                .HasMaxLength(55)
                .HasColumnName("real_name");
            entity.Property(e => e.RlimbData).HasColumnName("rlimb_data");
            entity.Property(e => e.RunechatColor)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#FFFFFF'")
                .HasColumnName("runechat_color");
            entity.Property(e => e.SecRecord).HasColumnName("sec_record");
            entity.Property(e => e.SecondaryFacialHairColour)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("secondary_facial_hair_colour");
            entity.Property(e => e.SecondaryHairColour)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("secondary_hair_colour");
            entity.Property(e => e.SkinColour)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#000000'")
                .HasColumnName("skin_colour");
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
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("connection_log")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.HasIndex(e => e.Ckey, "ckey");

            entity.HasIndex(e => e.Computerid, "computerid");

            entity.HasIndex(e => e.Ip, "ip");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Computerid)
                .HasMaxLength(32)
                .HasColumnName("computerid")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.Ip)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ip");
            entity.Property(e => e.Result)
                .HasDefaultValueSql("'ESTABLISHED'")
                .HasColumnType("enum('ESTABLISHED','DROPPED - IPINTEL','DROPPED - BANNED','DROPPED - INVALID')")
                .HasColumnName("result")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.ServerId)
                .HasMaxLength(50)
                .HasColumnName("server_id")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Customuseritem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("customuseritems")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.HasIndex(e => e.CuiCkey, "cuiCKey");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CuiCkey)
                .HasMaxLength(36)
                .HasColumnName("cuiCKey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CuiDescription)
                .HasColumnType("text")
                .HasColumnName("cuiDescription")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CuiItemName)
                .HasColumnType("text")
                .HasColumnName("cuiItemName")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CuiJobMask)
                .HasColumnType("text")
                .HasColumnName("cuiJobMask")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CuiPath)
                .HasMaxLength(255)
                .HasColumnName("cuiPath")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CuiPropAdjust)
                .HasColumnType("text")
                .HasColumnName("cuiPropAdjust")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CuiRealName)
                .HasMaxLength(60)
                .HasColumnName("cuiRealName")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CuiReason)
                .HasColumnType("text")
                .HasColumnName("cuiReason")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Death>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("death")
                .UseCollation("utf8mb4_uca1400_ai_ci");

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
                .HasColumnName("byondkey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Coord)
                .HasComment("X, Y, Z POD")
                .HasColumnType("text")
                .HasColumnName("coord")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.DeathRid)
                .HasColumnType("int(11)")
                .HasColumnName("death_rid");
            entity.Property(e => e.Fireloss)
                .HasColumnType("int(11)")
                .HasColumnName("fireloss");
            entity.Property(e => e.Gender)
                .HasColumnType("text")
                .HasColumnName("gender")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Job)
                .HasColumnType("text")
                .HasColumnName("job")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Lakey)
                .HasComment("Last attacker key")
                .HasColumnType("text")
                .HasColumnName("lakey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Laname)
                .HasComment("Last attacker name")
                .HasColumnType("text")
                .HasColumnName("laname")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.LastWords)
                .HasColumnType("text")
                .HasColumnName("last_words")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Oxyloss)
                .HasColumnType("int(11)")
                .HasColumnName("oxyloss");
            entity.Property(e => e.Pod)
                .HasComment("Place of death")
                .HasColumnType("text")
                .HasColumnName("pod")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.ServerId)
                .HasColumnType("text")
                .HasColumnName("server_id")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Special)
                .HasColumnType("text")
                .HasColumnName("special")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Tod)
                .HasComment("Time of death")
                .HasColumnType("datetime")
                .HasColumnName("tod");
        });

        modelBuilder.Entity<Donator>(entity =>
        {
            entity.HasKey(e => e.PatreonName).HasName("PRIMARY");

            entity
                .ToTable("donators")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Ckey, "ckey");

            entity.Property(e => e.PatreonName)
                .HasMaxLength(32)
                .HasColumnName("patreon_name");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasComment("Manual Field")
                .HasColumnName("ckey");
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
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("feedback")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.Json)
                .HasColumnName("json")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.KeyName)
                .HasMaxLength(32)
                .HasColumnName("key_name")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.KeyType)
                .HasColumnType("enum('text','amount','tally','nested tally','associative','ledger','nested ledger')")
                .HasColumnName("key_type")
                .HasCharSet("utf8mb4");
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

            entity
                .ToTable("instance_data_cache")
                .HasCharSet("utf8mb4")
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
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("last_updated");
        });

        modelBuilder.Entity<Ip2group>(entity =>
        {
            entity.HasKey(e => e.Ip).HasName("PRIMARY");

            entity
                .ToTable("ip2group")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.HasIndex(e => e.Groupstr, "groupstr");

            entity.Property(e => e.Ip)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ip");
            entity.Property(e => e.Date)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("date");
            entity.Property(e => e.Groupstr)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("groupstr");
        });

        modelBuilder.Entity<Ipintel>(entity =>
        {
            entity.HasKey(e => e.Ip).HasName("PRIMARY");

            entity
                .ToTable("ipintel")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.Property(e => e.Ip)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ip");
            entity.Property(e => e.Date)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("date");
            entity.Property(e => e.Intel).HasColumnName("intel");
        });

        modelBuilder.Entity<JsonDatumSafe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("json_datum_saves")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Ckey, "ckey");

            entity.HasIndex(e => new { e.Ckey, e.Slotname }, "ckey_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Ckey)
                .HasMaxLength(64)
                .HasColumnName("ckey");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Slotjson).HasColumnName("slotjson");
            entity.Property(e => e.Slotname)
                .HasMaxLength(32)
                .HasColumnName("slotname");
            entity.Property(e => e.Updated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("updated");
        });

        modelBuilder.Entity<LegacyPopulation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("legacy_population")
                .UseCollation("utf8mb4_uca1400_ai_ci");

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
                .HasColumnName("server_id")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("library")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Ckey, "ckey");

            entity.HasIndex(e => e.Reports, "flagged").HasAnnotation("MySql:IndexPrefixLength", new[] { 1024 });

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasColumnType("mediumtext")
                .HasColumnName("author");
            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey");
            entity.Property(e => e.Content)
                .HasColumnType("mediumtext")
                .HasColumnName("content");
            entity.Property(e => e.PrimaryCategory)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("primary_category");
            entity.Property(e => e.Raters)
                .HasColumnType("mediumtext")
                .HasColumnName("raters")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Rating)
                .HasDefaultValueSql("'0'")
                .HasColumnName("rating");
            entity.Property(e => e.Reports)
                .HasColumnType("mediumtext")
                .HasColumnName("reports")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SecondaryCategory)
                .HasColumnType("int(11)")
                .HasColumnName("secondary_category");
            entity.Property(e => e.Summary)
                .HasColumnType("mediumtext")
                .HasColumnName("summary")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TertiaryCategory)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("tertiary_category");
            entity.Property(e => e.Title)
                .HasColumnType("mediumtext")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Memo>(entity =>
        {
            entity.HasKey(e => e.Ckey).HasName("PRIMARY");

            entity
                .ToTable("memo")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Edits)
                .HasColumnType("text")
                .HasColumnName("edits")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.LastEditor)
                .HasMaxLength(32)
                .HasColumnName("last_editor")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Memotext)
                .HasColumnType("text")
                .HasColumnName("memotext")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("notes")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.HasIndex(e => e.Ckey, "ckey");

            entity.HasIndex(e => e.Deleted, "deleted");

            entity.HasIndex(e => e.Public, "public");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Adminckey)
                .HasMaxLength(32)
                .HasColumnName("adminckey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Automated)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("automated");
            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CrewPlaytime)
                .HasDefaultValueSql("'0'")
                .HasColumnType("mediumint(8) unsigned")
                .HasColumnName("crew_playtime");
            entity.Property(e => e.Deleted)
                .HasColumnType("tinyint(4)")
                .HasColumnName("deleted");
            entity.Property(e => e.Deletedby)
                .HasMaxLength(32)
                .HasColumnName("deletedby")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Edits)
                .HasColumnType("text")
                .HasColumnName("edits")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.LastEditor)
                .HasMaxLength(32)
                .HasColumnName("last_editor")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Notetext)
                .HasColumnType("text")
                .HasColumnName("notetext")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Public)
                .HasColumnType("tinyint(4)")
                .HasColumnName("public");
            entity.Property(e => e.RoundId)
                .HasColumnType("int(11)")
                .HasColumnName("round_id");
            entity.Property(e => e.Server)
                .HasMaxLength(50)
                .HasColumnName("server")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<OauthToken>(entity =>
        {
            entity.HasKey(e => e.Token).HasName("PRIMARY");

            entity
                .ToTable("oauth_tokens")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.HasIndex(e => e.Ckey, "ckey");

            entity.Property(e => e.Token)
                .HasMaxLength(32)
                .HasColumnName("token")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<PaiSafe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pai_saves")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.Ckey, "ckey").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("player")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Ckey, "ckey").IsUnique();

            entity.HasIndex(e => e.Computerid, "computerid");

            entity.HasIndex(e => e.Fuid, "fuid");

            entity.HasIndex(e => e.Fupdate, "fupdate");

            entity.HasIndex(e => e.Ip, "ip");

            entity.HasIndex(e => e.Lastseen, "lastseen");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Atklog)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(4)")
                .HasColumnName("atklog");
            entity.Property(e => e.BeRole).HasColumnName("be_role");
            entity.Property(e => e.ByondDate).HasColumnName("byond_date");
            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey");
            entity.Property(e => e.Clientfps)
                .HasDefaultValueSql("'100'")
                .HasColumnType("smallint(4)")
                .HasColumnName("clientfps");
            entity.Property(e => e.ColourblindMode)
                .HasMaxLength(48)
                .HasDefaultValueSql("'None'")
                .HasColumnName("colourblind_mode")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.Computerid)
                .HasMaxLength(32)
                .HasColumnName("computerid");
            entity.Property(e => e.DefaultSlot)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(4)")
                .HasColumnName("default_slot");
            entity.Property(e => e.Exp).HasColumnName("exp");
            entity.Property(e => e.Firstseen)
                .HasColumnType("datetime")
                .HasColumnName("firstseen");
            entity.Property(e => e.Fuid)
                .HasColumnType("bigint(20)")
                .HasColumnName("fuid");
            entity.Property(e => e.Fupdate)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(4)")
                .HasColumnName("fupdate");
            entity.Property(e => e.GhostDarknessLevel)
                .HasDefaultValueSql("'255'")
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("ghost_darkness_level");
            entity.Property(e => e.Glowlevel)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("glowlevel");
            entity.Property(e => e.Ip)
                .HasMaxLength(18)
                .HasColumnName("ip");
            entity.Property(e => e.Keybindings).HasColumnName("keybindings");
            entity.Property(e => e.Lastchangelog)
                .HasMaxLength(32)
                .HasDefaultValueSql("'0'")
                .HasColumnName("lastchangelog");
            entity.Property(e => e.Lastseen)
                .HasColumnType("datetime")
                .HasColumnName("lastseen");
            entity.Property(e => e.Light)
                .HasDefaultValueSql("'7'")
                .HasColumnType("mediumint(3)")
                .HasColumnName("light");
            entity.Property(e => e.MapVotePrefJson)
                .HasColumnType("mediumtext")
                .HasColumnName("map_vote_pref_json")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.MutedAdminsoundsCkeys)
                .HasColumnType("mediumtext")
                .HasColumnName("muted_adminsounds_ckeys")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.Ooccolor)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#b82e00'")
                .HasColumnName("ooccolor");
            entity.Property(e => e.Parallax)
                .HasDefaultValueSql("'8'")
                .HasColumnName("parallax");
            entity.Property(e => e.ScreentipColor)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#ffd391'")
                .HasColumnName("screentip_color");
            entity.Property(e => e.ScreentipMode)
                .HasDefaultValueSql("'8'")
                .HasColumnName("screentip_mode");
            entity.Property(e => e.ServerRegion)
                .HasMaxLength(32)
                .HasColumnName("server_region")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.Sound)
                .HasDefaultValueSql("'31'")
                .HasColumnType("mediumint(8)")
                .HasColumnName("sound");
            entity.Property(e => e.Toggles)
                .HasColumnType("int(11)")
                .HasColumnName("toggles");
            entity.Property(e => e.Toggles2)
                .HasColumnType("int(11)")
                .HasColumnName("toggles_2");
            entity.Property(e => e.Toggles3)
                .HasColumnType("int(11)")
                .HasColumnName("toggles_3");
            entity.Property(e => e.UiStyle)
                .HasMaxLength(10)
                .HasDefaultValueSql("'Midnight'")
                .HasColumnName("UI_style");
            entity.Property(e => e.UiStyleAlpha)
                .HasDefaultValueSql("'255'")
                .HasColumnType("smallint(4)")
                .HasColumnName("UI_style_alpha");
            entity.Property(e => e.UiStyleColor)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#ffffff'")
                .HasColumnName("UI_style_color");
            entity.Property(e => e.Viewrange)
                .HasMaxLength(5)
                .HasDefaultValueSql("'19x15'")
                .HasColumnName("viewrange")
                .UseCollation("utf8mb4_general_ci");
            entity.Property(e => e.VolumeMixer).HasColumnName("volume_mixer");
            entity.Property(e => e._2faStatus)
                .HasDefaultValueSql("'DISABLED'")
                .HasColumnType("enum('DISABLED','ENABLED_IP','ENABLED_ALWAYS')")
                .HasColumnName("2fa_status")
                .UseCollation("utf8mb4_general_ci");
        });

        modelBuilder.Entity<PlaytimeHistory>(entity =>
        {
            entity.HasKey(e => new { e.Ckey, e.Date })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("playtime_history")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.TimeCommand)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_command");
            entity.Property(e => e.TimeCrew)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_crew");
            entity.Property(e => e.TimeEngineering)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_engineering");
            entity.Property(e => e.TimeGhost)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_ghost");
            entity.Property(e => e.TimeLiving)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_living");
            entity.Property(e => e.TimeMedical)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_medical");
            entity.Property(e => e.TimeScience)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_science");
            entity.Property(e => e.TimeSecurity)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_security");
            entity.Property(e => e.TimeService)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_service");
            entity.Property(e => e.TimeSilicon)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_silicon");
            entity.Property(e => e.TimeSpecial)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_special");
            entity.Property(e => e.TimeSupply)
                .HasColumnType("smallint(6)")
                .HasColumnName("time_supply");
        });

        modelBuilder.Entity<Privacy>(entity =>
        {
            entity.HasKey(e => e.Ckey).HasName("PRIMARY");

            entity
                .ToTable("privacy")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Consent)
                .HasColumnType("bit(1)")
                .HasColumnName("consent");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
        });

        modelBuilder.Entity<Round>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("round")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CommitHash)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("commit_hash")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.EndDatetime)
                .HasColumnType("datetime")
                .HasColumnName("end_datetime");
            entity.Property(e => e.EndState)
                .HasMaxLength(64)
                .HasColumnName("end_state")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.GameMode)
                .HasMaxLength(32)
                .HasColumnName("game_mode")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.GameModeResult)
                .HasMaxLength(64)
                .HasColumnName("game_mode_result")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.InitializeDatetime)
                .HasColumnType("datetime")
                .HasColumnName("initialize_datetime");
            entity.Property(e => e.MapName)
                .HasMaxLength(32)
                .HasColumnName("map_name")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.ServerId)
                .HasMaxLength(50)
                .HasColumnName("server_id")
                .HasCharSet("utf8mb4");
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
                .HasColumnName("shuttle_name")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.StartDatetime)
                .HasColumnType("datetime")
                .HasColumnName("start_datetime");
            entity.Property(e => e.StationName)
                .HasMaxLength(80)
                .HasColumnName("station_name")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tickets")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AllResponses).HasColumnName("all_responses");
            entity.Property(e => e.Awho).HasColumnName("awho");
            entity.Property(e => e.EndRoundState)
                .HasColumnType("enum('OPEN','CLOSED','RESOLVED','STALE','UNKNOWN')")
                .HasColumnName("end_round_state");
            entity.Property(e => e.RealFiletime)
                .HasColumnType("datetime")
                .HasColumnName("real_filetime");
            entity.Property(e => e.RelativeFiletime)
                .HasColumnType("time")
                .HasColumnName("relative_filetime");
            entity.Property(e => e.TicketCreator)
                .HasMaxLength(32)
                .HasColumnName("ticket_creator");
            entity.Property(e => e.TicketNum)
                .HasColumnType("int(11)")
                .HasColumnName("ticket_num");
            entity.Property(e => e.TicketTakeTime)
                .HasColumnType("datetime")
                .HasColumnName("ticket_take_time");
            entity.Property(e => e.TicketTaker)
                .HasMaxLength(32)
                .HasColumnName("ticket_taker");
            entity.Property(e => e.TicketTopic)
                .HasColumnType("text")
                .HasColumnName("ticket_topic");
            entity.Property(e => e.TicketType)
                .HasColumnType("enum('ADMIN','MENTOR')")
                .HasColumnName("ticket_type");
        });

        modelBuilder.Entity<VpnWhitelist>(entity =>
        {
            entity.HasKey(e => e.Ckey).HasName("PRIMARY");

            entity
                .ToTable("vpn_whitelist")
                .UseCollation("utf8mb4_uca1400_ai_ci");

            entity.Property(e => e.Ckey)
                .HasMaxLength(32)
                .HasColumnName("ckey")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Reason)
                .HasColumnType("text")
                .HasColumnName("reason")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<Watch>(entity =>
        {
            entity.HasKey(e => e.Ckey).HasName("PRIMARY");

            entity
                .ToTable("watch")
                .HasCharSet("utf8mb4")
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

        modelBuilder.Entity<_2faSecret>(entity =>
        {
            entity.HasKey(e => e.Ckey).HasName("PRIMARY");

            entity
                .ToTable("2fa_secrets")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Ckey)
                .HasMaxLength(50)
                .HasColumnName("ckey");
            entity.Property(e => e.DateSetup)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("date_setup");
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
