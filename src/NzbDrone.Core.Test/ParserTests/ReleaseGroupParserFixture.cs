using FluentAssertions;
using NUnit.Framework;
using NzbDrone.Core.Test.Framework;

namespace NzbDrone.Core.Test.ParserTests
{
    [TestFixture]
    public class ReleaseGroupParserFixture : CoreTest
    {
        [TestCase("Castle.2009.S01E14.English.HDTV.XviD-LOL", "LOL")]
        [TestCase("Castle 2009 S01E14 English HDTV XviD LOL", null)]
        [TestCase("Acropolis Now S05 EXTRAS DVDRip XviD RUNNER", null)]
        [TestCase("Punky.Brewster.S01.EXTRAS.DVDRip.XviD-RUNNER", "RUNNER")]
        [TestCase("2020.NZ.2011.12.02.PDTV.XviD-C4TV", "C4TV")]
        [TestCase("The.Office.S03E115.DVDRip.XviD-OSiTV", "OSiTV")]
        [TestCase("The Office - S01E01 - Pilot [HTDV-480p]", null)]
        [TestCase("The Office - S01E01 - Pilot [HTDV-720p]", null)]
        [TestCase("The Office - S01E01 - Pilot [HTDV-1080p]", null)]
        [TestCase("The.Walking.Dead.S04E13.720p.WEB-DL.AAC2.0.H.264-Cyphanix", "Cyphanix")]
        [TestCase("Arrow.S02E01.720p.WEB-DL.DD5.1.H.264.mkv", null)]
        [TestCase("Series Title S01E01 Episode Title", null)]
        [TestCase("The Colbert Report - 2014-06-02 - Thomas Piketty.mkv", null)]
        [TestCase("Real Time with Bill Maher S12E17 May 23, 2014.mp4", null)]
        [TestCase("Reizen Waes - S01E08 - Transistri\u00EB, Zuid-Osseti\u00EB en Abchazi\u00EB SDTV.avi", null)]
        [TestCase("Simpsons 10x11 - Wild Barts Cant Be Broken [rl].avi", "rl")]
        [TestCase("[ www.Torrenting.com ] - Revenge.S03E14.720p.HDTV.X264-DIMENSION", "DIMENSION")]
        [TestCase("Seed S02E09 HDTV x264-2HD [eztv]-[rarbg.com]", "2HD")]
        [TestCase("7s-atlantis-s02e01-720p.mkv", null)]
        [TestCase("The.Middle.720p.HEVC.x265-MeGusta-Pre", "MeGusta")]
        [TestCase("Blue.Bloods.S08E05.The.Forgotten.1080p.AMZN.WEB-DL.DDP5.1.H.264-NTb-Rakuv", "NTb")]
        [TestCase("Lie.To.Me.S01E13.720p.BluRay.x264-SiNNERS-Rakuvfinhel", "SiNNERS")]
        [TestCase("Who.is.America.S01E01.INTERNAL.720p.HDTV.x264-aAF-RakuvUS-Obfuscated", "aAF")]
        [TestCase("Haunted.Hayride.2018.720p.WEBRip.DDP5.1.x264-NTb-postbot", "NTb")]
        [TestCase("Haunted.Hayride.2018.720p.WEBRip.DDP5.1.x264-NTb-xpost", "NTb")]
        [TestCase("2.Broke.Girls.S02E24.1080p.AMZN.WEBRip.DD5.1.x264-CasStudio-AsRequested", "CasStudio")]
        [TestCase("Billions.S04E11.Lamster.1080p.AMZN.WEB-DL.DDP5.1.H.264-NTb-AlternativeToRequested", "NTb")]
        [TestCase("NCIS.S16E04.Third.Wheel.1080p.AMZN.WEB-DL.DDP5.1.H.264-NTb-GEROV", "NTb")]
        [TestCase("Will.and.Grace.S10E06.Kid.n.Play.1080p.AMZN.WEB-DL.DDP5.1.H.264-NTb-Z0iDS3N", "NTb")]
        [TestCase("Absolute.Power.S02E06.The.House.of.Lords.DVDRip.x264-MaG-Chamele0n", "MaG")]
        [TestCase("Kai.Po.Che.2013.1080p.BluRay.REMUX.AVC.DTS-X.MA.5.1", null)]
        [TestCase("Kai.Po.Che.2013.1080p.BluRay.REMUX.AVC.DTS-MA.5.1", null)]
        [TestCase("Kai.Po.Che.2013.1080p.BluRay.REMUX.AVC.DTS-ES.MA.5.1", null)]
        [TestCase("SomeMovie.1080p.BluRay.DTS-X.264.-D-Z0N3.mkv", "D-Z0N3")]
        [TestCase("SomeMovie.1080p.BluRay.DTS.x264.-Blu-bits.mkv", "Blu-bits")]
        [TestCase("SomeMovie.1080p.BluRay.DTS.x264.-DX-TV.mkv", "DX-TV")]
        [TestCase("SomeMovie.1080p.BluRay.DTS.x264.-FTW-HS.mkv", "FTW-HS")]
        [TestCase("SomeMovie.1080p.BluRay.DTS.x264.-VH-PROD.mkv", "VH-PROD")]
        [TestCase("Some.Dead.Movie.2006.1080p.BluRay.DTS.x264.D-Z0N3", "D-Z0N3")]

        //[TestCase("", "")]

        //Exception Cases
        public void should_parse_exception_release_group(string title, string expected)
        {
            Parser.Parser.ParseReleaseGroup(title).Should().Be(expected);
        }

        [TestCase("Stargirl (2020) [2160p x265 10bit S82 Joy]", "Joy")]
        [TestCase("The Matrix Revolutions (2003) (2160p BluRay X265 HEVC 10bit HDR AAC 7.1 Tigole) [QxR]", "Tigole")]
        [TestCase("Ode To Joy (2009) (2160p BluRay x265 10bit HDR Joy)", "Joy")]
        [TestCase("Shingeki No Kyojin a.k.a. Attack on Titan S04E03 The Door of Hope 1080p NF WEB-DL DDP2.0 x264-E.N.D", "E.N.D")]
        [TestCase("The Curse of Audrey Earnshaw (2020) [1080p] [WEBRip] [5.1] [YTS.MX]", "YTS.MX")]
        [TestCase("The.Nightingale.2018.1080p.Blu-ray.Remux.AVC.DTS-HD.MA.5.1.KRaLiMaRKo", "KRaLiMaRKo")]
        [TestCase("Ode To Joy (2009) (2160p BluRay x265 10bit HDR FreetheFish)", "FreetheFish")]
        [TestCase("Ode To Joy (2009) (2160p BluRay x265 10bit HDR afm72)", "afm72")]
        [TestCase("Ode To Joy (2009) (2160p BluRay x265 10bit HDR)", null)]
        [TestCase("Marvel One Shot - Item 47 (2012) (1080p BluRay x265 HEVC 10bit AC3 2.0 Anna)", "Anna")]
        [TestCase("Anna (2019) (1080p BluRay x265 HEVC 10bit AAC 7.1 Q22 Joy)", "Joy")]
        [TestCase("Parasite (2019) (2160p BluRay x265 HEVC 10bit HDR AAC 7.1 Bandi)", "Bandi")]
        [TestCase("Robin Williams - Weapons of Self Destruction (2009) (1080p HDTV x265 HEVC 10bit AAC 2.0 Ghost)", "Ghost")]
        [TestCase("Ghost in the Shell (2017) (1080p BluRay x265 HEVC 10bit AAC 7.1 Tigole)", "Tigole")]
        [TestCase("Mission - Impossible - Ghost Protocol (2011) (1080p BluRay x265 HEVC 10bit AAC 7.1 Tigole)", "Tigole")]
        [TestCase("Ghost (1990) (1080p BluRay x265 HEVC 10bit AAC 5.1 Silence)", "Silence")]
        [TestCase("Happy End (1999) (1080p BluRay x265 HEVC 10bit AAC 5.1 Korean Kappa)", "Kappa")]
        [TestCase("Harry Potter and the Order of the Phoenix (2007) Open Matte (1080p AMZN WEB-DL x265 HEVC 10bit AAC 5.1 MONOLITH)", "MONOLITH")]
        [TestCase("Spider-Man Far from Home (2019) (1080p BluRay x265 HEVC 10bit DTS 7.1 Qman)", "Qman")]
        [TestCase("Suicide Squad - Hell to Pay (2018) + Extras (1080p BluRay x265 HEVC 10bit AAC 5.1 RZeroX)", "RZeroX")]
        [TestCase("Gravity (2013) (Diamond Luxe Edition) + Extras (1080p BluRay x265 HEVC 10bit EAC3 7.1 SAMPA)", "SAMPA")]
        [TestCase("Wonder Woman 1984 (2020) (1080p AMZN WEB-DL x265 HEVC 10bit EAC3 5.1 Silence)", "Silence")]
        [TestCase("The.Silence.of.the.Lambs.1991.REMASTERED.720p.10bit.BluRay.6CH.x265.HEVC-PSA", "PSA")]
        [TestCase("Seoul Station 2016 (1080p BluRay x265 HEVC 10bit DDP 5.1 theincognito)", "theincognito")]
        [TestCase("Harry Potter - A History of Magic (2017) (1080p AMZN WEB-DL x265 HEVC 10bit EAC3 2.0 t3nzin)", "t3nzin")]
        [TestCase("John Wick Chapter 3 Parabellum (2019) (1080p BluRay x265 HEVC 10bit AAC 7.1 Vyndros)", "Vyndros")]

        public void should_parse_release_group(string title, string expected)
        {
            Parser.Parser.ParseReleaseGroup(title).Should().Be(expected);
        }

        [TestCase("Marvels.Daredevil.S02E04.720p.WEBRip.x264-SKGTV English", "SKGTV")]
        [TestCase("Marvels.Daredevil.S02E04.720p.WEBRip.x264-SKGTV_English", "SKGTV")]
        [TestCase("Marvels.Daredevil.S02E04.720p.WEBRip.x264-SKGTV.English", "SKGTV")]

        //[TestCase("", "")]
        public void should_not_include_language_in_release_group(string title, string expected)
        {
            Parser.Parser.ParseReleaseGroup(title).Should().Be(expected);
        }

        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-RP", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-RP-RP", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-Obfuscation", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-NZBgeek", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-1", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-sample.mkv", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-Scrambled", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-postbot", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-xpost", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-Rakuv", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-Rakuv02", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-Rakuvfinhel", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-Obfuscated", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-WhiteRev", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-BUYMORE", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-AsRequested", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-AlternativeToRequested", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-GEROV", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-Z0iDS3N", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-Chamele0n", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-4P", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-EVO-4Planet", "EVO")]
        [TestCase("Rambo.Last.Blood.2019.1080p.BDRip.X264.AC3-DON-AlteZachen", "DON")]
        public void should_not_include_repost_in_release_group(string title, string expected)
        {
            Parser.Parser.ParseReleaseGroup(title).Should().Be(expected);
        }

        [TestCase("[FFF] Invaders of the Rokujouma!! - S01E11 - Someday, With Them", "FFF")]
        [TestCase("[HorribleSubs] Invaders of the Rokujouma!! - S01E12 - Invasion Going Well!!", "HorribleSubs")]
        [TestCase("[Anime-Koi] Barakamon - S01E06 - Guys From Tokyo", "Anime-Koi")]
        [TestCase("[Anime-Koi] Barakamon - S01E07 - A High-Grade Fish", "Anime-Koi")]
        [TestCase("[Anime-Koi] Kami-sama Hajimemashita 2 - 01 [h264-720p][28D54E2C]", "Anime-Koi")]

        //[TestCase("Tokyo.Ghoul.02x01.013.HDTV-720p-Anime-Koi", "Anime-Koi")]
        //[TestCase("", "")]
        public void should_parse_anime_release_groups(string title, string expected)
        {
            Parser.Parser.ParseReleaseGroup(title).Should().Be(expected);
        }
    }
}
