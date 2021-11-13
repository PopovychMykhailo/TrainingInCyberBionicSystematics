/****************************************************************************
************************   T R A N S A C T - S Q L   ************************
*****************************************************************************
*****  Lesson III  *****            SELECT           ************************
****************************************************************************/

-- вставка данных сгенериваных с помощью  сайта https://www.generatedata.com/
-- процесс генерации данных можно посмотреть в 3 уроке курса TRANSACT SQL Станислва Зуйка
---- https://itvdn.com/ru/video/ssms_tsql/select

CREATE DATABASE TEST_DB  ON 
(
	NAME = 'TEST_DB', 						-- Логическое имя файла БД
	FILENAME = 'D:\Work\DBs\TEST_DB.mdf',   -- Физическое имя БД
	SIZE = 5MB,								-- Начальний размер
	MAXSIZE = 10MB,							-- Максимальний размер
	FILEGROWTH = 1MB						-- Прирост
)

USE TEST_DB

IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Employees'))
BEGIN;
    DROP TABLE [Employees];
END;
GO

CREATE TABLE [Employees] (
    [Id] INTEGER NOT NULL IDENTITY(1, 1),
    [FName] VARCHAR(255) NULL,
    [LName] VARCHAR(255) NULL,
    [Phone] VARCHAR(100) NULL,
    [EMail] VARCHAR(255) NULL,
    [BirthDate] DATE,
    [Department] VARCHAR(255) NULL,
    [Address] VARCHAR(255) NULL,
    [Salary] DECIMAL(10,4) NULL,
    PRIMARY KEY ([Id])
);
GO

INSERT INTO Employees
	([FName],[LName],[Phone],[EMail],[BirthDate],[Department],[Address],[Salary]) 
VALUES
	('Melanie','Chandler','072-247-7280','porttitor.tellus.non@CraspellentesqueSed.net','19870807','SUPPLY','427-1407VelAvenue','10000'),
	('Francesca','Jarvis','022-475-6735','turpis.Nulla@enimdiamvel.org','19870329','SALES','387-2130SitRd.','7000'),
	('Heather','Gaines','049-799-3650','blandit.at@tristique.co.uk','19950618','LOGISTICS','Ap#522-1013RisusRd.','9000'),
	('Jakeem','Perry','004-776-9218','elementum@tellusfaucibusleo.org','19811214','ADMINISTRATION&SUPPORT','Ap#356-2366DisAvenue','10000'),
	('Ella','Clayton','019-155-8217','hendrerit.id.ante@lobortisultrices.edu','19790304','PRODUCTION&ENGINEERING','P.O.Box771,8699NetusAvenue','5000'),
	('Winter','Cantrell','035-932-4526','nibh.Donec@fringillacursuspurus.edu','19801208','PLANNED-ECONOMIC','621-5915PedeRoad','5000'),
	('Adele','Fletcher','046-173-2765','luctus.et.ultrices@est.org','19930417','HRMANAGEMENT','4812UtSt.','5000'),
	('Mollie','Pate','064-317-7981','ac.libero@sitamet.net','19821229','LOGISTICS','6533Ut,Ave','7000'),
	('Silas','Acevedo','002-675-9781','nisl.elementum.purus@utpharetrased.co.uk','19910202','LAW','527-5115AcSt.',NULL),
	('Emma','Roman','090-343-8857','lorem@odiotristique.net','19790814','LOGISTICS','Ap#955-7018Arcu.Av.','9000'),
	('Dora','Brown','070-126-0788','lacus@odio.edu','19881223','SALES','956-9584AccumsanStreet',NULL),
	('Fitzgerald','Gardner','053-341-4738','vitae.velit@ipsumprimisin.ca','19790602','LOGISTICS','Ap#749-7533FringillaRoad','6000'),
	('Richard','Schneider','061-406-9308','velit.dui.semper@nisinibhlacinia.net','19821015','PRODUCTION&ENGINEERING','Ap#940-6450Ornare,Street','4000'),
	('Carter','Lloyd','065-247-9717','at@gravidamolestie.co.uk','19910815','LAW','Ap#376-7504RisusAvenue','9000'),
	('Brynn','Johnson','030-375-5413','ultrices.sit.amet@ut.com','19840309','FINANCE&ACCOUNTING','Ap#972-2994MetusRoad','6000'),
	('Evelyn','Colon','075-514-3543','elit@velitdui.org','19790223','PRODUCTION&ENGINEERING','226-2025EgetSt.',NULL),
	('Sigourney','Bradshaw','007-905-5284','erat.semper.rutrum@quisturpisvitae.org','19880730','HRMANAGEMENT','Ap#861-3112Sapien,Street','7000'),
	('Gil','Jacobson','089-255-7891','In@tellus.net','19930312','SALES','319-4405InRd.','6000'),
	('Angelica','Butler','062-772-2733','a@volutpatNulla.org','19870316','ADMINISTRATION&SUPPORT','P.O.Box910,5957Dui.St.','9000'),
	('Uriah','Pope','062-858-8720','Nunc@MorbivehiculaPellentesque.edu','19880401','LAW','638DisSt.','7000'),
	('Beverly','Conley','043-945-8933','Suspendisse@Aeneansedpede.ca','19890213','SALES','P.O.Box597,5329EuRd.','7000'),
	('Kyle','Gilliam','004-729-1965','risus@nonvestibulum.org','19880719','PRODUCTION&ENGINEERING','P.O.Box334,2625Tortor.St.','10000'),
	('Amethyst','Cabrera','098-799-7451','eu.dolor@imperdiet.co.uk','19821008','ADMINISTRATION&SUPPORT','P.O.Box396,1079SedAvenue','8000'),
	('Marshall','Emerson','043-675-3538','consectetuer.cursus@duiSuspendisseac.co.uk','19891205','PLANNED-ECONOMIC','P.O.Box804,9174BlanditRoad','7000'),
	('Bruno','Miranda','009-488-9793','Mauris@amet.net','19840224','ADMINISTRATION&SUPPORT','296-6188DictumStreet','9000'),
	('Dustin','Osborn','051-645-9866','nec@Integervitae.org','19870820','SALES','P.O.Box114,4650Luctus.Road','5000'),
	('Frances','Reilly','046-443-1891','lectus.justo@id.co.uk','19881203','HRMANAGEMENT','3545AcRd.','8000'),
	('Roanna','Farley','036-125-6360','amet.lorem@risusodioauctor.net','19891001','MARKETING','P.O.Box990,8498UtSt.','10000'),
	('Germane','Arnold','005-278-5377','Pellentesque.habitant@Aliquamrutrumlorem.net','19920122','SUPPLY','Ap#415-970Metus.St.','9000'),
	('Kylie','Crosby','031-501-5067','Donec.egestas@egetvariusultrices.org','19891223','PRODUCTION&ENGINEERING','Ap#131-1422LuctusAv.','4000'),
	('Ryder','Fox','037-346-6031','nec.leo@Sedid.org','19860913','PRODUCTION&ENGINEERING','9177OrciSt.',NULL),
	('Arden','Cooley','063-001-3259','habitant.morbi.tristique@erat.co.uk','19810310','PRODUCTION&ENGINEERING','776-5053Quis,Road','5000'),
	('Halla','Miles','059-870-7474','sodales.at.velit@Nullamfeugiat.org','19801129','SALES','237-3434PellentesqueAv.','5000'),
	('Clarke','Erickson','015-401-8447','a.dui.Cras@Nuncmauris.co.uk','19930215','ADMINISTRATION&SUPPORT','1639VelAvenue','10000'),
	('Sebastian','Pennington','079-205-2414','elementum.dui.quis@tempusloremfringilla.com','19801012','SUPPLY','7381AtRoad','4000'),
	('Chelsea','Crosby','063-984-9232','penatibus.et@utquamvel.ca','19790912','SUPPLY','Ap#610-4796AmetSt.','7000'),
	('Channing','Robles','003-565-8807','In@asollicitudin.ca','19860119','PRODUCTION&ENGINEERING','P.O.Box321,9092PrimisStreet','7000'),
	('Debra','Hardin','075-722-3873','id.ante.dictum@amet.org','19870922','SUPPLY','4144ConvallisAv.','8000'),
	('Perry','Sanders','041-731-6906','vel.vulputate@ante.org','19800318','SALES','P.O.Box760,7173QuisAve','6000'),
	('Stone','Slater','094-294-9156','erat.neque@sit.ca','19810709','SUPPLY','3578NullaRd.','9000'),
	('Edan','Blevins','030-021-1822','lobortis@adipiscinglobortis.co.uk','19910923','SUPPLY','885-6097CommodoAvenue','7000'),
	('Hamilton','Russell','096-736-0878','ornare@Donecfringilla.ca','19800208','MARKETING','P.O.Box523,4903In,Ave','7000'),
	('Gary','Knox','051-124-7854','elit.Curabitur.sed@nonjusto.com','19890221','SALES','5610MaurisRd.','7000'),
	('Alika','Stevens','086-036-0030','penatibus.et.magnis@Quisquetinciduntpede.edu','19820910','LOGISTICS','878VestibulumRd.','4000'),
	('Connor','Rodgers','045-936-4974','sed@Cumsociis.com','19880830','SALES','Ap#752-7751Cursus.Road','4000'),
	('Gray','Joyner','014-632-0942','non.lorem.vitae@Crassedleo.net','19920824','PRODUCTION&ENGINEERING','Ap#533-3149DonecAv.','9000'),
	('Quinn','Mcmillan','023-689-2512','amet@velitduisemper.co.uk','19890904','SALES','Ap#323-1500PhasellusStreet','7000'),
	('Bradley','Gould','001-417-8555','mattis.semper.dui@fermentumfermentum.org','19840201','PRODUCTION&ENGINEERING','Ap#751-6712AcRd.','4000'),
	('Nayda','Pittman','009-529-7327','ipsum.Suspendisse@feugiat.com','19940911','QUALITYASSURANCE&CONTROL','Ap#616-1566CommodoRd.',NULL),
	('Aquila','Cantu','005-110-3982','non.bibendum@elementumduiquis.co.uk','19900428','PLANNED-ECONOMIC','199-9516IntegerSt.','5000'),
	('Kieran','Morse','063-264-1960','amet@convallisligula.ca','19801017','MARKETING','9674EgestasAvenue','6000'),
	('Yolanda','Mcgowan','012-280-3793','vel@sapiencursus.net','19910718','LAW','328-3564ConvallisRd.','5000'),
	('Holmes','Hodges','042-202-7174','blandit@vestibulumnequesed.ca','19821011','LAW','106-3332Ornare,St.','7000'),
	('Pandora','Kim','040-161-8455','Sed.diam@Donec.net','19900103','ADMINISTRATION&SUPPORT','P.O.Box341,7759Mattis.St.','5000'),
	('Shafira','Malone','087-236-7220','Integer@eu.org','19820509','HRMANAGEMENT','9968PellentesqueAv.','9000'),
	('Inez','Pate','069-185-2566','feugiat.Lorem.ipsum@aptenttacitisociosqu.edu','19840608','LOGISTICS','831-6642FaucibusSt.','10000'),
	('Macaulay','Vega','051-451-0570','tristique.aliquet@placerat.com','19910823','ADMINISTRATION&SUPPORT','Ap#209-2940MagnisSt.','10000'),
	('Xavier','Suarez','026-239-3181','leo@nonenimcommodo.net','19861127','SALES','P.O.Box771,1679MiSt.','9000'),
	('Nora','Ochoa','004-001-1314','parturient@Fuscemollis.co.uk','19940205','PRODUCTION&ENGINEERING','P.O.Box373,8120EgetAvenue','6000'),
	('Alec','Good','058-738-4059','vulputate@egestasAliquamfringilla.co.uk','19800427','LAW','269-7032NamRd.','8000'),
	('Wade','Mckay','075-068-3413','Curabitur.ut.odio@molestieintempus.co.uk','19950227','SALES','296-4977EtAv.','10000'),
	('Kerry','Pope','084-749-6590','ut.erat.Sed@eueleifend.edu','19780525','LAW','4143AdRd.','5000'),
	('Lee','Herrera','066-894-8661','eget.dictum@tellus.com','19881021','FINANCE&ACCOUNTING','P.O.Box638,6162SuspendisseAve','8000'),
	('Baxter','Wall','006-288-7734','volutpat.Nulla@Nuncpulvinar.org','19890502','MARKETING','Ap#721-3781IdAvenue','6000'),
	('Melodie','Delaney','011-380-1062','Donec.vitae@ridiculus.org','19790406','SUPPLY','Ap#943-5032Sem,Avenue','9000'),
	('Isadora','Tyson','052-549-0207','ridiculus.mus@eratEtiam.edu','19870402','HRMANAGEMENT','P.O.Box993,1126ConsectetuerStreet','4000'),
	('Zane','Mcfarland','027-081-0471','ipsum@auctorMauris.ca','19900215','MARKETING','469-6286Sagittis.St.','4000'),
	('Madonna','Ashley','043-418-2583','dui.nec@sapienAenean.net','19930610','ADMINISTRATION&SUPPORT','P.O.Box161,989Quis,St.','4000'),
	('Jocelyn','Charles','012-673-4905','velit@SeddictumProin.org','19900104','FINANCE&ACCOUNTING','Ap#463-8479AcRd.','4000'),
	('Joan','Parsons','090-961-5227','orci.luctus@fringillaporttitorvulputate.org','19890213','LOGISTICS','8842Massa.St.','8000'),
	('Marcia','Mckay','029-380-1632','Curabitur.massa@Quisqueliberolacus.net','19900509','LOGISTICS','P.O.Box342,9580AmetAv.','6000'),
	('Omar','Blevins','038-908-2268','nulla@magnaSuspendissetristique.org','19830717','HRMANAGEMENT','458Placerat,Rd.','5000'),
	('Hoyt','Hernandez','006-137-8862','sed.facilisis.vitae@quisaccumsanconvallis.edu','19861026','PLANNED-ECONOMIC','2272NuncAve','10000'),
	('Inez','Solomon','067-778-5796','velit.egestas@sapienimperdietornare.edu','19851205','LAW','Ap#233-7666At,Road','5000'),
	('Beau','Winters','055-062-5817','ac.sem@leoelementum.net','19920227','FINANCE&ACCOUNTING','Ap#290-8271LuctusAve','4000'),
	('Aphrodite','Floyd','065-094-8464','eu@senectuset.net','19930213','PRODUCTION&ENGINEERING','P.O.Box188,5839Tincidunt,Avenue','7000'),
	('Forrest','Serrano','082-012-5069','imperdiet@fringillaest.com','19910309','PLANNED-ECONOMIC','P.O.Box551,8431RisusRd.','10000'),
	('Denton','Padilla','032-943-1360','Curabitur.egestas.nunc@dictumplacerataugue.net','19870801','SALES','Ap#179-5349FamesAve','5000'),
	('Christian','Ferguson','059-965-2510','arcu.ac.orci@consequatlectus.co.uk','19900315','SUPPLY','145-848DolorSt.',NULL),
	('Charlotte','Chavez','077-071-4541','tempus@convalliserat.ca','19830520','PLANNED-ECONOMIC','6730Mi.Rd.','9000'),
	('Lucy','Macias','018-644-6686','arcu.Sed.et@Donec.co.uk','19790809','LAW','591-5164PosuereSt.','7000'),
	('Griffith','Finley','002-656-3616','urna.et@ornaresagittisfelis.com','19931102','LOGISTICS','Ap#336-579LigulaRd.',NULL),
	('Alfonso','Pennington','010-641-2141','luctus.aliquet@cursusaenim.ca','19890728','SALES','P.O.Box429,5862PhasellusSt.','4000'),
	('Tamekah','Soto','074-143-1290','diam@risusDonec.com','19911207','PRODUCTION&ENGINEERING','P.O.Box195,5257PlaceratAve','8000'),
	('Paul','Goodwin','039-300-8966','non.sapien.molestie@Nullatempor.ca','19851211','LOGISTICS','765-3608SedAv.','7000'),
	('Keelie','Poole','028-723-0296','Duis.gravida@lobortisnisi.org','19831122','SALES','P.O.Box357,4106Enim,St.',NULL),
	('Stuart','Roman','060-833-1730','risus@senectus.edu','19850911','LOGISTICS','P.O.Box773,9216PortaAve','7000'),
	('Helen','Clayton','070-818-1910','pede@placerat.org','19830604','MARKETING','Ap#851-4338NonummySt.','7000'),
	('Lucian','Black','030-960-2141','Nullam.velit@augue.org','19871123','FINANCE&ACCOUNTING','655-608MorbiSt.',NULL),
	('Troy','Velasquez','090-115-2192','sed.pede@Donec.co.uk','19790414','LAW','P.O.Box461,1015LoremAvenue','4000'),
	('Castor','Glass','020-002-5837','porttitor.interdum@uterat.com','19891230','PRODUCTION&ENGINEERING','Ap#553-286ProinAvenue','6000'),
	('Ora','Simmons','064-460-9185','tellus.faucibus@Praesenteudui.net','19780216','HRMANAGEMENT','Ap#850-6201EgetAve','10000'),
	('Mohammad','Higgins','094-701-3101','conubia.nostra.per@disparturient.net','19860904','ADMINISTRATION&SUPPORT','817-9872Diam.Av.','9000'),
	('Lani','Moss','078-791-6171','sed@Nuncsedorci.com','19890412','SUPPLY','5460QuisqueSt.','9000'),
	('Macaulay','Scott','027-055-9516','imperdiet.erat@eu.net','19900621','SUPPLY','380-2378PorttitorStreet',NULL),
	('Rylee','Poole','039-758-6332','Pellentesque.ultricies@est.org','19870816','PLANNED-ECONOMIC','394-9885VehiculaSt.',NULL),
	('Carla','Crawford','044-316-9118','libero.lacus@aliquam.co.uk','19910812','SALES','P.O.Box991,645LitoraAve','10000'),
	('Ralph','Franco','038-164-5040','vulputate@quamelementumat.co.uk','19910417','LOGISTICS','748NonRoad','4000'),
	('Britanney','Barr','027-475-2484','hymenaeos.Mauris@acarcuNunc.org','19780717','LAW','8731NequeRd.','5000'),
	('Maxine','Baker','089-750-1809','consequat@senectusetnetus.edu','19810302','LOGISTICS','229-7613TristiqueStreet','6000')
GO