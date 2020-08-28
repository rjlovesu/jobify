using Jobify.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Jobify.Services {
    class UserService : Service {

        public User loggedUser { get; private set; }


		//TODO replace this
		private static List<User> allUsers = new List<User>{
            new User("admin","Admin","Admin","admin")
            ,new User("janis.berzins@gmail.com","Jānis","Bērziņš","parole123")
            ,new User("XÆA-Xiimusk@gmail.com","X Æ A-Xii","Musk","password321")
            ,new User("BeverlySales@gmail.com","Beverly","Sales","safepassword")
            ,new User("MaryCash@gmail.com","Mary","Cash","safepassword")
			,new User("shazia.farrow@gmail.com", "Shazia", "Farrow", "2FNKK8ZHFW")
			,new User("karim.simons@gmail.com", "Karim", "Simons", "W7X1B86N0E")
			,new User("eoghan.krause@gmail.com", "Eoghan", "Krause", "ZKNEPEA6CB")
			,new User("aarush.garner@gmail.com", "Aarush", "Garner", "WOO5YL4UDM")
			,new User("conah.mejia@gmail.com", "Conah", "Mejia", "AZ57RG8DIF")
			,new User("noel.gibson@gmail.com", "Noel", "Gibson", "D0VZ85Y5QR")
			,new User("shantelle.seymour@gmail.com", "Shantelle", "Seymour", "8PLEI8EE78")
			,new User("carmel.chapman@gmail.com", "Carmel", "Chapman", "JRXI3QGGW5")
			,new User("shivani.young@gmail.com", "Shivani", "Young", "IAED2ACQZY")
			,new User("tia.koch@gmail.com", "Tia", "Koch", "QH12RR101N")
			,new User("sanna.kidd@gmail.com", "Sanna", "Kidd", "NF2RQ5AER2")
			,new User("caspian.bentley@gmail.com", "Caspian", "Bentley", "7U56AK1T78")
			,new User("shannan.firth@gmail.com", "Shannan", "Firth", "K0WLC1Y0Q7")
			,new User("kimberly.mcculloch@gmail.com", "Kimberly", "Mcculloch", "SL2RQF3HRH")
			,new User("levison.townsend@gmail.com", "Levison", "Townsend", "L2UTZL22DH")
			,new User("ollie.ross@gmail.com", "Ollie", "Ross", "UZA4PV0AP9")
			,new User("gwion.vu@gmail.com", "Gwion", "Vu", "2YYT4ODRZV")
			,new User("benjamin.mcmanus@gmail.com", "Benjamin", "Mcmanus", "RVSZOEDTOK")
			,new User("layla.kerr@gmail.com", "Layla", "Kerr", "KDU0SP1MXL")
			,new User("jules.jarvis@gmail.com", "Jules", "Jarvis", "C0VQ2JSKG2")
			,new User("todd.barajas@gmail.com", "Todd", "Barajas", "LDF9W0F7X9")
			,new User("saqib.gilmore@gmail.com", "Saqib", "Gilmore", "CXMU1SPQ38")
			,new User("renee.boyd@gmail.com", "Renee", "Boyd", "3DEELR21O6")
			,new User("raheel.kendall@gmail.com", "Raheel", "Kendall", "6W7682VJ20")
			,new User("karan.kay@gmail.com", "Karan", "Kay", "MOSJIYAH8Q")
			,new User("josh.peel@gmail.com", "Josh", "Peel", "SATNP6KQMN")
			,new User("kit.moody@gmail.com", "Kit", "Moody", "X46SO4X4JB")
			,new User("grayson.floyd@gmail.com", "Grayson", "Floyd", "SHI3OBPDZZ")
			,new User("waqas.ryder@gmail.com", "Waqas", "Ryder", "XI5MSRWD6Y")
			,new User("shayne.dawson@gmail.com", "Shayne", "Dawson", "YY46RDYLFE")
			,new User("constance.york@gmail.com", "Constance", "York", "9GOG0GTI4E")
			,new User("isabel.soto@gmail.com", "Isabel", "Soto", "25XRXF634Y")
			,new User("carlos.correa@gmail.com", "Carlos", "Correa", "VMDTMWF6LZ")
			,new User("ellie-mae.morrison@gmail.com", "Ellie-Mae", "Morrison", "QXFS7YG2G9")
			,new User("daniella.phillips@gmail.com", "Daniella", "Phillips", "J83CDAK26V")
			,new User("indigo.edmonds@gmail.com", "Indigo", "Edmonds", "X67AUSV034")
			,new User("usmaan.richmond@gmail.com", "Usmaan", "Richmond", "GXCZBB20HP")
			,new User("renzo.dudley@gmail.com", "Renzo", "Dudley", "SHSBQH1K3L")
			,new User("eadie.alston@gmail.com", "Eadie", "Alston", "UJ2MLVK38V")
			,new User("darci.drew@gmail.com", "Darci", "Drew", "C2Q1HZUJKI")
			,new User("elis.perez@gmail.com", "Elis", "Perez", "1TFMYIKIAX")
			,new User("ashwin.cartwright@gmail.com", "Ashwin", "Cartwright", "88B7AMM2KU")
			,new User("jameson.johns@gmail.com", "Jameson", "Johns", "3SKJNSM8L2")
			,new User("shiloh.vance@gmail.com", "Shiloh", "Vance", "JP3CE6K9OB")
			,new User("gracie-may.mccormick@gmail.com", "Gracie-May", "Mccormick", "MZB0CJU57J")
			,new User("hakim.chung@gmail.com", "Hakim", "Chung", "TC51IR0BAU")
			,new User("pawel.beltran@gmail.com", "Pawel", "Beltran", "0S9GX823BO")
			,new User("rhiannan.franks@gmail.com", "Rhiannan", "Franks", "W9L49Y8YNQ")
			,new User("karl.hahn@gmail.com", "Karl", "Hahn", "V2AX91RN6W")
			,new User("hadi.cuevas@gmail.com", "Hadi", "Cuevas", "RQ7M9VTKJU")
			,new User("yasmeen.thatcher@gmail.com", "Yasmeen", "Thatcher", "JULMNG1R3A")
			,new User("nevaeh.sampson@gmail.com", "Nevaeh", "Sampson", "GAVCY398KN")
			,new User("kalum.watkins@gmail.com", "Kalum", "Watkins", "KC48DMLVP4")
			,new User("tyrell.kirk@gmail.com", "Tyrell", "Kirk", "2HIGKSDEFR")
			,new User("marwa.gardiner@gmail.com", "Marwa", "Gardiner", "36JK0CAV1L")
			,new User("leo.palacios@gmail.com", "Leo", "Palacios", "1BMS5P5CIW")
			,new User("rory.tucker@gmail.com", "Rory", "Tucker", "GXX5TWTBHL")
			,new User("carlton.witt@gmail.com", "Carlton", "Witt", "QHMH2LW7Q9")
			,new User("tahmina.page@gmail.com", "Tahmina", "Page", "NQ7VUDAPO6")
			,new User("catherine.gallagher@gmail.com", "Catherine", "Gallagher", "E29L259EX9")
			,new User("kaan.walter@gmail.com", "Kaan", "Walter", "1R1GOJU74R")
			,new User("gia.choi@gmail.com", "Gia", "Choi", "1HRTN3PCKP")
			,new User("garrett.wilkes@gmail.com", "Garrett", "Wilkes", "DNVQXIDJPL")
			,new User("lani.sinclair@gmail.com", "Lani", "Sinclair", "IRDIXQBKWB")
			,new User("bianca.marin@gmail.com", "Bianca", "Marin", "PO7DQL5W9M")
			,new User("morgan.davidson@gmail.com", "Morgan", "Davidson", "QSO1TYCNF9")
			,new User("chantel.elliott@gmail.com", "Chantel", "Elliott", "MNTRRI582K")
			,new User("zack.example@gmail.com", "Zack", "Example", "password1")
			,new User("eilish.slater@gmail.com", "Eilish", "Slater", "YNYVSH75E7")
			,new User("shah.cervantes@gmail.com", "Shah", "Cervantes", "NBSS132EII")
			,new User("eryn.wheatley@gmail.com", "Eryn", "Wheatley", "J8PFSC09RT")
			,new User("iestyn.mohammed@gmail.com", "Iestyn", "Mohammed", "Q4ZNX802HG")
			,new User("keeleigh.mccarthy@gmail.com", "Keeleigh", "Mccarthy", "FUQ6LUKPGN")
			,new User("heather.gale@gmail.com", "Heather", "Gale", "9VR4B36NVH")
			,new User("bert.mclean@gmail.com", "Bert", "Mclean", "SF4JEOGFE7")
			,new User("lenny.cantrell@gmail.com", "Lenny", "Cantrell", "582DVN2R2F")
			,new User("luci.partridge@gmail.com", "Luci", "Partridge", "5QBPPOCF7G")
			,new User("arlo.weber@gmail.com", "Arlo", "Weber", "PXEU2LZIZ5")
			,new User("kim.wardle@gmail.com", "Kim", "Wardle", "61AN670N2G")
			,new User("taliah.villa@gmail.com", "Taliah", "Villa", "V455SNFU1Z")
			,new User("harper-rose.talbot@gmail.com", "Harper-Rose", "Talbot", "MN2IPDYD6P")
			,new User("maeve.spence@gmail.com", "Maeve", "Spence", "IUTCN4MBZ5")
			,new User("kaia.gough@gmail.com", "Kaia", "Gough", "B1W8RN7M60")
			,new User("pearce.maguire@gmail.com", "Pearce", "Maguire", "5IE98XOKK2")
			,new User("aiza.deleon@gmail.com", "Aiza", "Deleon", "O8CYH48V5C")
			,new User("ryley.dodd@gmail.com", "Ryley", "Dodd", "D75NP0VK4F")
			,new User("amelia-grace.brennan@gmail.com", "Amelia-Grace", "Brennan", "A53L4VGCGP")
			,new User("vivien.atkinson@gmail.com", "Vivien", "Atkinson", "KOPO7D083B")
			,new User("mert.yu@gmail.com", "Mert", "Yu", "0CZ014W719")
			,new User("firat.mckay@gmail.com", "Firat", "Mckay", "QRVQD1SM8L")
			,new User("diane.dyer@gmail.com", "Diane", "Dyer", "3YYVKHBM9W")
			,new User("katey.walker@gmail.com", "Katey", "Walker", "IZKPKGIUZD")
			,new User("amin.nieves@gmail.com", "Amin", "Nieves", "TLLIJI5VNO")
			,new User("rhianne.travis@gmail.com", "Rhianne", "Travis", "LYFFGUL7NF")
			,new User("maisy.foley@gmail.com", "Maisy", "Foley", "P81DIG34H4")
			,new User("aiyla.marquez@gmail.com", "Aiyla", "Marquez", "7QCEL8AW4Y")
			,new User("rogan.garrett@gmail.com", "Rogan", "Garrett", "T5DTRN10KX")
			,new User("samantha.ramos@gmail.com", "Samantha", "Ramos", "H9WKIBVOII")
			,new User("renesmee.morrow@gmail.com", "Renesmee", "Morrow", "3QYXRM41XM")
			,new User("zayaan.higgins@gmail.com", "Zayaan", "Higgins", "9PG7LIF7GH")

		};



        public User LoginUserByEmailAndPassword(string email, string password) {
            loggedUser = allUsers.SingleOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password));
            return loggedUser;
        }

        public User FindUserByEmail(string email) {
            return allUsers.SingleOrDefault(user => user.Email.Equals(email));
        }

        public override void Init() {

		}

		public void Logout() {
			loggedUser = null;
		}

    }


}
