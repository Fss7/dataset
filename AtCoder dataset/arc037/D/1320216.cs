using static System.Console;
class P
{
	const long M = 1000000007;
	static void Main()
	{
		var L = int.Parse(ReadLine());
		var b = a[L >> 10];
		//var b = a[0];
		long p = b[0], q = b[1], r = b[2], z;
		L &= 1023;
		for (var i = 0; i < L; i++)
		{
			/*if (i % 1024 == 0)
			{
				if (p < 0) p += M;
				if (q < 0) q += M;
				if (r < 0) r += M;
				WriteLine($"new[]{{{p}L, {q}L, {r}L}},");
			}*/
			z = (p + q) * (p - q) % M;
			r = (p * p % M * p + (r << 1) + r) % M;
			q = q * z % M;
			p = p * (p + z) % M;
		}
		if (r < 0) r += M;
		WriteLine(r);
	}
	static readonly long[][] a = new[] {
		new[]{ 2L, 1L, 1L },
		new[]{ 253357240L, 966602706L, 181289323L },
		new[]{ 226488541L, 637077364L, 911403282L },
		new[]{ 974637096L, 857448644L, 321345816L },
		new[]{ 576163578L, 305265661L, 873741983L },
		new[]{ 95567922L, 689655321L, 309597407L },
		new[]{ 765175196L, 730027755L, 298518203L },
		new[]{ 24382263L, 948070025L, 306647423L },
		new[]{ 228256187L, 545342314L, 42750805L },
		new[]{ 102219130L, 750795329L, 603411002L },
		new[]{ 306092958L, 617497346L, 635089063L },
		new[]{ 511587273L, 567111286L, 856758835L },
		new[]{ 58124743L, 398103822L, 185265876L },
		new[]{ 177217251L, 575399022L, 205831446L },
		new[]{ 930741545L, 259248356L, 312055705L },
		new[]{ 210154821L, 141155979L, 209582225L },
		new[]{ 317279065L, 886497016L, 554859000L },
		new[]{ 893243229L, 202829975L, 232257778L },
		new[]{ 807395042L, 433824502L, 149798385L },
		new[]{ 547152137L, 369959173L, 903798794L },
		new[]{ 20419296L, 922799435L, 185846990L },
		new[]{ 229306056L, 198899306L, 565284992L },
		new[]{ 335311244L, 464160052L, 521199198L },
		new[]{ 880520166L, 921719198L, 442907980L },
		new[]{ 821694060L, 834411289L, 902280078L },
		new[]{ 402626226L, 334980302L, 394928791L },
		new[]{ 863100525L, 525164234L, 699371551L },
		new[]{ 276139113L, 477024333L, 88688583L },
		new[]{ 305324684L, 35940457L, 688017169L },
		new[]{ 728607735L, 173289544L, 810068431L },
		new[]{ 133822270L, 709456551L, 636340793L },
		new[]{ 846680613L, 893981888L, 324919070L },
		new[]{ 598917832L, 855260831L, 829523743L },
		new[]{ 522132236L, 719284920L, 335643427L },
		new[]{ 956259350L, 597470186L, 595062439L },
		new[]{ 335551647L, 119166399L, 745158831L },
		new[]{ 304513296L, 449663175L, 616578340L },
		new[]{ 155298473L, 228428059L, 601621347L },
		new[]{ 465453280L, 955411966L, 329952901L },
		new[]{ 226088943L, 612177706L, 540595879L },
		new[]{ 417490193L, 636324216L, 153951244L },
		new[]{ 596468037L, 59715583L, 694405440L },
		new[]{ 643847019L, 332626758L, 168642248L },
		new[]{ 419472526L, 776858382L, 864317216L },
		new[]{ 393638485L, 695953037L, 282980329L },
		new[]{ 356490414L, 283275056L, 967065230L },
		new[]{ 605817536L, 31011256L, 963190856L },
		new[]{ 255858019L, 654523828L, 780566048L },
		new[]{ 350206930L, 901552014L, 715136139L },
		new[]{ 652325063L, 970222358L, 616194869L },
		new[]{ 717973800L, 162985713L, 322811785L },
		new[]{ 699526081L, 719137072L, 794008622L },
		new[]{ 270908867L, 273637619L, 411943152L },
		new[]{ 497318238L, 447250388L, 661280524L },
		new[]{ 958825258L, 387315343L, 54677545L },
		new[]{ 62336021L, 588521663L, 393497655L },
		new[]{ 459387809L, 993207208L, 276287277L },
		new[]{ 968899243L, 948732257L, 906973395L },
		new[]{ 955696301L, 222524094L, 278359830L },
		new[]{ 287173608L, 937401347L, 654889859L },
		new[]{ 713753376L, 531709990L, 138461519L },
		new[]{ 23215571L, 919841720L, 942726674L },
		new[]{ 500890500L, 694816497L, 755490995L },
		new[]{ 602753765L, 487702363L, 215359268L },
		new[]{ 937602785L, 890722340L, 398800024L },
		new[]{ 844506340L, 341089690L, 694781267L },
		new[]{ 220828473L, 153026827L, 905200895L },
		new[]{ 844590730L, 976421155L, 330646732L },
		new[]{ 775621780L, 303379851L, 386162101L },
		new[]{ 375001477L, 978323853L, 303390871L },
		new[]{ 630887211L, 162289493L, 597605143L },
		new[]{ 324350382L, 262378143L, 891281600L },
		new[]{ 340655475L, 567651910L, 225678148L },
		new[]{ 383869849L, 41394652L, 450828362L },
		new[]{ 876004956L, 954607517L, 491432949L },
		new[]{ 510346554L, 190421772L, 587912224L },
		new[]{ 567105295L, 774730012L, 94350712L },
		new[]{ 804727405L, 269827810L, 793420390L },
		new[]{ 977731582L, 464068494L, 946327139L },
		new[]{ 791139098L, 242231479L, 27020197L },
		new[]{ 415748204L, 806244050L, 734299957L },
		new[]{ 219534712L, 987868668L, 163976206L },
		new[]{ 621597249L, 338098490L, 736778159L },
		new[]{ 153244806L, 249802148L, 864620193L },
		new[]{ 539866001L, 546025331L, 583467892L },
		new[]{ 488181971L, 942281251L, 116848155L },
		new[]{ 888599132L, 595154978L, 348558646L },
		new[]{ 927930374L, 720672855L, 982424438L },
		new[]{ 779735417L, 881200882L, 619819162L },
		new[]{ 695987840L, 509304412L, 26422194L },
		new[]{ 649929696L, 821244562L, 87247151L },
		new[]{ 331245963L, 908490300L, 975589403L },
		new[]{ 704278559L, 184150118L, 78047104L },
		new[]{ 379704582L, 973444369L, 420456638L },
		new[]{ 944299897L, 582588409L, 306962259L },
		new[]{ 15776538L, 592355162L, 69412915L },
		new[]{ 744097162L, 736247015L, 578873237L },
		new[]{ 239352235L, 667488008L, 516537304L }
	};
}