CREATE DATABASE [ClupStore]
GO
USE [ClupStore]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Billing] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartLine]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartLine](
	[CartLineID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_CartLine] PRIMARY KEY CLUSTERED 
(
	[CartLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Subject] [nvarchar](250) NULL,
	[Phone] [nvarchar](11) NULL,
	[Massage] [nvarchar](max) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImageURL] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](450) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[Zip] [nvarchar](max) NULL,
	[Line1] [nvarchar](max) NOT NULL,
	[Line2] [nvarchar](max) NULL,
	[Line3] [nvarchar](max) NULL,
	[RegisteratedDate] [datetime] NOT NULL,
	[RenewDate] [datetime] NOT NULL,
	[Baid] [bit] NOT NULL,
	[GiftWrap] [bit] NOT NULL,
	[Shipped] [bit] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/7/2019 2:41:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201908241715207_CityProperty', N'WebGUI.Migrations.Configuration', 0x1F8B0800000000000400E55C6D6FE33612FE7E40FF83A04FED21B5F2D25DEC05768BAC93B446372F5827BDFBB6A025DA2156A254914A131CFACBEEC3FDA4FB0B474AD41B45CA9225CB0A8A0245CC976786C32167389AD9FFFDE7BFD39F5E3CD7788621413E9E99279363D380D8F61D84373333A2EBEF3F983FFDF8CDDFA6578EF762FC968E3BE3E3D84C4C66E613A5C1B96511FB097A804C3C64873EF1D77462FB9E051CDF3A3D3EFE87757262410661322CC3987E8E30451E8C7FB09F731FDB30A011706F7C07BA44B4B39E658C6ADC020F9200D87066FE13AE7E7E5C4C16781D0242C3C8A651084DE3C2458031B384EEDA3400C63E0594B17AFE48E092863EDE2C03D600DC87D700B2716BE0122896709E0F6FBA9AE353BE1A2B9F9842D911A1BED712F0E44C88C792A7EF246433131F13E01513347DE5AB8E853833170E8C9B3EFB2E13804CF07CEE867CF0CCBCC9485C90E016D2493A7192405E870CEE0F3FFC3A29221E198DE71D65EA743A39E6FF1D19F3C8E5BB39C330A221708F8CFB68E522FB57F8FAE07F85787676B25A9F7D78F71E3867EF7F8067EF8A2B656B65E34A0DACE93EF4031832DEE03A5BBF6958E579963C319B5698934885E9123B19A671035E3E41BCA14FECCC9C7E308D6BF4029DB44528D72346EC20B1494C4BD9CFDBC875C1CA8559BF554B93FFBF86EAE9BBF7BD50BD05CF68136FBD449F1D9C9098C667E8C6BDE40905C9F12AEDF71731EC3AF43DFEBBAC5F49EF97A51F85365F8CAF1DF200C20DA465EEA656AEBC8D549A43F5AFD629EAF8559B735A556FE550BEA05D4E424A62E8D390F2BB5FBA8D35EE2208B6299AB05389419B88094746D29C2BC8495305C18C71D3F808081432908FA2B41415CF7CF75AF1CC2774E5F9AF7B47B33F1B51AD27F211B96E8CBC673A571E406E0F16A70115E6EFAD51E8C16CCB3EFA4C81016EBD01F7801076E13ABF00F2B477012DA11D85EC4C2D29F082BD53BB7FF231BC8DBC153FB2C3D1EA6D6B1EFEF0AF814DFDF00AF3599DF13EF9F6573FA257D8B904143E523B05E43F1F90D71CA017762E6C1B1272CD94193A739F3D6752C005A667A7ADE1F8457B688F6FEE02E4A95D3E610ABEA4437277AFDC5371F5A46E959B57C7D2277F83703D4BE9902A4B498F9625D1DD96250E52CF9118516528EED0F293F4F6E608C712EFDF138E61C7EF0A77F3207467B820C625BBD9E0CF10C3905D3FCE3DA0148638DF8126E7FD101E4BBC7D9CE8DE6D4A4CE937E0467D93DAE934C487BDFFD310C38EFF34C46CB2E667E4706FA2C1FB301DCCE01B8D573F3DB79F3989B3A18F43699943131FE60ED01D970B427C1BC5A740111914719D32FFCCF732B6077974AFD31BA6E82860AACD5AD8DA4C59A9EEF025742185C6859D444EE780D8C0A98A912DC869C1586A51158CE501A332737FAFD0649A0E433E09F0C70B612715615A3D1608DB2800EE562949331B9A30BEF68C86DC7309038839C1AD9268425C1D1FE20C6474A44DD926A1A955D0B87A4594BC4DDD5EEB5CCF7C9FB390C720BAA7F175357A27FCB3BD289E5A3203289D5A044D086B6397432A9C784B6CDB60F961716885935E321A85132ED05E15AE2C990115AE2C8237A370C95371DBFE4AEFC643AB5BF9A13ABC59558A65405D2BAD7F64AA96F87A6C0E65336098AB5BBA37972BDE095FA8E231C4F814EF21225C4B591538C212D2722824F72FB77E955080C84A5307982BD61650F155B202941D98164CA531AF5AAE84356F019BC6AD6A61C59D2DC116F6BE8A5DFC2A5B18A8FF762B2B65232F3F5B59A60515E56EE4941770148A205F4EE58537108A1CB7AC0AA4CED76CE26D161620845E23088D87A81142CA746F5248554E2F059503D4C405DA490A92DBA29142CA746F5210BAA51782C2283730CB3B89A06C4A7B3A0CE98B3FB30259DFD44AF2A944C3D4D2245E4D6F401020BC292462891663996461CDBF5FB6CF4DF2120CCB268A14A58CDB8C12F543B081522F23CD38BD4621A197808215E0F18EB9E35586296D9EE67A4E4916CD5A75F3D27B3A1DCDFF16772FE17FDFADBF5526A7952EDDEF141E8300BC66CBF5B8BB11C79615CA109BBECA748367C90117848A70F6DC77230FEBBD1FFDECE46354717ED25245985A12FF152FA722BA36B2558B344DC0189D3099A63928F6F4E3D8772155A438FD12113B441EC28071371AA1D68B6674922DBB99838A37EDCFEF8E46374BF556EF6FD332DF78F78DD343E8362F7DD91485AF7BEDE851D26063114517803CD8DEE99CE51D6EAEF809D27E9BB4330F6D01740859E65211246B6C8E2332938A28A2A9254621B9A50256E86B8E5ACE3F2A62967B9A234A49464548A9AB0597C554A21293C58E9DF03412558F684EA19A3C5444AFF6364756A41115A115DD3B602B7896FB9AA32A328D8AC08AEEE6D879DA917C83EFCBDBEBC1726A9FEA5D4C6712C0E9663B3518FBB99EFB31BD857C902250A1B92596C8F8A88089F6512A9436EAD145A192D05D3785D260E8EF9F523245F9FAA9CD00D1639632244A577C5D86881EAF9DDAEE55392A71127948463D8B97487191A988516CAF5AAB042D9221A6918A9199F75742A137E10326CBDFDDB98B20BFCCD3013700A3352434C90A324F8F4F4EA5AAB7F154A0598438AE22C6A32B432BEFD900097EF81984F61308ABE9361D2A0072D0CA97950576E0CBCCFC773CEB3C0E02F2BFE2E62363411E31FA3D621D0F61048D3FAB69BF2DB992DEBF9DD6DC67155626863FDF447953F30D5DFCEB4B32F5C8B80BD9613D378EA56DDC45B9CA454FADB849A676E0A64D2954F555FAE6CFF0B71E78F9AE88B443A54E27AC52358E72A9D2C5B07BF1CD0AD15E0A6F3AAD57595CD309515140D3175E2F22D415C8EC82A52D8E71D84F1A17C7B45BACBA586617D6B4853208B70793CB649ADF89E9CC7E4C6E878A8CC1EFC958CE5BCB153AE52E1FDA5056AA1A3A1DF46AE5420BB85EAB13BAF94B6F2CEBBF377BAE48EAEF0DFB907ABFF74CFEB124EFE72F88C3E6EC0F99A65FF3F9EE4D67E71F305F55919F77B85CFCA1754917CF1E692274B3CCFB91289330D787CBB31F5A9974B1EC912A53A3ACFA91E8D2A1ECDC8134A9B1893B78CE7C35CD50F35D4915D0DE96139F44FFD9F37CE5B3CD4F3CBEA474589DECA923962B8996603E444F549F652A13CE0E4A855ED6534FA6DDDA8461AE5D9C18534F56934B5D475BDCE3B5B4C5987ADA9A0CE64364F12B738C5515155BEEABBAE4B13166ED9738D614816CF31D6B3FFA8F3149BFD3A24BDAAFF9303DBE9CFC4E4BEE53B55BE4E057BF21335B56F8F751993D25689343F044580CED9215CBC62CF0DA4F8DA9C4513A448A68DC400A1C66E22E428AD6C0A6AC9B076CE3EF1822D1F6CA5B416781EF221A44942D197A2BB71420E246B98E7E5C6850E6797A17C4FF7C4E1F4B606C221EE8BEC31F23E43A19DFD78A188A06825B7B111EE57B49799874F39A21DDFAB82190105FE6A43C402F701918B9C34BF00C77E18DA9DF27B801F66B1E31D3816CDF88B2D8A797086C42E0118191CF673F990E3BDECB8FFF073DE0ACF126580000, N'6.2.0-61023')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201908311725498_mig2', N'WebGUI.Migrations.Configuration', 0x1F8B0800000000000400E55C6D6FE33612FE7E40FF83A04FED21B5F2D25DEC05768BAC93B446372F5827BDFBB6A025DA2156A254914A131CFACBEEC3FDA4FB0B474AD41B45CA9225CB0A8A0245CC976786C32167389AD9FFFDE7BFD39F5E3CD7788621413E9E99279363D380D8F61D84373333A2EBEF3F983FFDF8CDDFA6578EF762FC968E3BE3E3D84C4C66E613A5C1B96511FB097A804C3C64873EF1D77462FB9E051CDF3A3D3EFE87757262410661322CC3987E8E30451E8C7FB09F731FDB30A011706F7C07BA44B4B39E658C6ADC020F9200D87066FE13AE7E7E5C4C16781D0242C3C8A651084DE3C2458031B384EEDA3400C63E0594B17AFE48E092863EDE2C03D600DC87D700B2716BE0122896709E0F6FBA9AE353BE1A2B9F9842D911A1BED712F0E44C88C792A7EF246433131F13E01513347DE5AB8E853833170E8C9B3EFB2E13804CF07CEE867CF0CCBCC9485C90E016D2493A7192405E870CEE0F3FFC3A29221E198DE71D65EA743A39E6FF1D19F3C8E5BB39C330A221708F8CFB68E522FB57F8FAE07F85787676B25A9F7D78F71E3867EF7F8067EF8A2B656B65E34A0DACE93EF4031832DEE03A5BBF6958E579963C319B5698934885E9123B19A671035E3E41BCA14FECCC9C7E308D6BF4029DB44528D72346EC20B1494C4BD9CFDBC875C1CA8559BF554B93FFBF86EAE9BBF7BD50BD05CF68136FBD449F1D9C9098C667E8C6BDE40905C9F12AEDF71731EC3AF43DFEBBAC5F49EF97A51F85365F8CAF1DF200C20DA465EEA656AEBC8D549A43F5AFD629EAF8559B735A556FE550BEA05D4E424A62E8D390F2BB5FBA8D35EE2208B6299AB05389419B88094746D29C2BC8495305C18C71D3F808081432908FA2B41415CF7CF75AF1CC2774E5F9AF7B47B33F1B51AD27F211B96E8CBC673A571E406E0F16A70115E6EFAD51E8C16CCB3EFA4C81016EBD01F7801076E13ABF00F2B477012DA11D85EC4C2D29F082BD53BB7FF231BC8DBC153FB2C3D1EA6D6B1EFEF0AF814DFDF00AF3599DF13EF9F6573FA257D8B904143E523B05E43F1F90D71CA017762E6C1B1272CD94193A739F3D6752C005A667A7ADE1F8457B688F6FEE02E4A95D3E610ABEA4437277AFDC5371F5A46E959B57C7D2277F83703D4BE9902A4B498F9625D1DD96250E52CF9118516528EED0F293F4F6E608C712EFDF138E61C7EF0A77F3207467B820C625BBD9E0CF10C3905D3FCE3DA0148638DF8126E7FD101E4BBC7D9CE8DE6D4A4CE937E0467D93DAE934C487BDFFD310C38EFF34C46CB2E667E4706FA2C1FB301DCCE01B8D573F3DB79F3989B3A18F43699943131FE60ED01D970B427C1BC5A740111914719D32FFCCF732B6077974AFD31BA6E82860AACD5AD8DA4C59A9EEF025742185C6859D444EE780D8C0A98A912DC869C1586A51158CE501A332737FAFD0649A0E433E09F0C70B612715615A3D1608DB2800EE562949331B9A30BEF68C86DC7309038839C1AD9268425C1D1FE20C6474A44DD926A1A955D0B87A4594BC4DDD5EEB5CCF7C9FB390C720BAA7F175357A27FCB3BD289E5A3203289D5A044D086B6397432A9C784B6CDB60F961716885935E321A85132ED05E15AE2C990115AE2C8237A370C95371DBFE4AEFC643AB5BF9A13ABC59558A65405D2BAD7F64AA96F87A6C0E65336098AB5BBA37972BDE095FA8E231C4F814EF21225C4B591538C212D2722824F72FB77E955080C84A5307982BD61650F155B202941D98164CA531AF5AAE84356F019BC6AD6A61C59D2DC116F6BE8A5DFC2A5B18A8FF762B2B65232F3F5B59A60515E56EE4941770148A205F4EE58537108A1CB7AC0AA4CED76CE26D161620845E23088D87A81142CA746F5248554E2F059503D4C405DA490A92DBA29142CA746F5210BAA51782C2283730CB3B89A06C4A7B3A0CE98B3FB30259DFD44AF2A944C3D4D2245E4D6F401020BC292462891663996461CDBF5FB6CF4DF2120CCB268A14A58CDB8C12F543B081522F23CD38BD4621A197808215E0F18EB9E35586296D9EE67A4E4916CD5A75F3D27B3A1DCDFF16772FE17FDFADBF5526A7952EDDEF141E8300BC66CBF5B8BB11C79615CA109BBECA748367C90117848A70F6DC77230FEBBD1FFDECE46354717ED25245985A12FF152FA722BA36B2558B344DC0189D3099A63928F6F4E3D8772155A438FD12113B441EC28071371AA1D68B6674922DBB99838A37EDCFEF8E46374BF556EF6FD332DF78F78DD343E8362F7DD91485AF7BEDE851D26063114517803CD8DEE99CE51D6EAEF809D27E9BB4330F6D01740859E65211246B6C8E2332938A28A2A9254621B9A50256E86B8E5ACE3F2A62967B9A234A49464548A9AB0597C554A21293C58E9DF03412558F684EA19A3C5444AFF6364756A41115A115DD3B602B7896FB9AA32A328D8AC08AEEE6D879DA917C83EFCBDBEBC1726A9FEA5D4C6712C0E9663B3518FBB99EFB31BD857C902250A1B92596C8F8A88089F6512A9436EAD145A192D05D3785D260E8EF9F523245F9FAA9CD00D1639632244A577C5D86881EAF9DDAEE55392A71127948463D8B97487191A988516CAF5AAB042D9221A6918A9199F75742A137E10326CBDFDDB98B20BFCCD3013700A3352434C90A324F8F4F4EA5AAB7F154A0598438AE22C6A32B432BEFD900097EF81984F61308ABE9361D2A0072D0CA97950576E0CBCCFC773CEB3C0E02F2BFE2E62363411E31FA3D621D0F61048D3FAB69BF2DB992DEBF9DD6DC67155626863FDF447953F30D5DFCEB4B32F5C8B80BD9613D378EA56DDC45B9CA454FADB849A676E0A64D2954F555FAE6CFF0B71E78F9AE88B443A54E27AC52358E72A9D2C5B07BF1CD0AD15E0A6F3AAD57595CD309515140D3175E2F22D415C8EC82A52D8E71D84F1A17C7B45BACBA586617D6B4853208B70793CB649ADF89E9CC7E4C6E878A8CC1EFC958CE5BCB153AE52E1FDA5056AA1A3A1DF46AE5420BB85EAB13BAF94B6F2CEBBF377BAE48EAEF0DFB907ABFF74CFEB124EFE72F88C3E6EC0F99A65FF3F9EE4D67E71F305F55919F77B85CFCA1754917CF1E692274B3CCFB91289330D787CBB31F5A9974B1EC912A53A3ACFA91E8D2A1ECDC8134A9B1893B78CE7C35CD50F35D4915D0DE96139F44FFD9F37CE5B3CD4F3CBEA474589DECA923962B8996603E444F549F652A13CE0E4A855ED6534FA6DDDA8461AE5D9C18534F56934B5D475BDCE3B5B4C5987ADA9A0CE64364F12B738C5515155BEEABBAE4B13166ED9738D614816CF31D6B3FFA8F3149BFD3A24BDAAFF9303DBE9CFC4E4BEE53B55BE4E057BF21335B56F8F751993D25689343F044580CED9215CBC62CF0DA4F8DA9C4513A448A68DC400A1C66E22E428AD6C0A6AC9B076CE3EF1822D1F6CA5B416781EF221A44942D197A2BB71420E246B98E7E5C6850E6797A17C4FF7C4E1F4B606C221EE8BEC31F23E43A19DFD78A188A06825B7B111EE57B49799874F39A21DDFAB82190105FE6A43C402F701918B9C34BF00C77E18DA9DF27B801F66B1E31D3816CDF88B2D8A797086C42E0118191CF673F990E3BDECB8FFF073DE0ACF126580000, N'6.2.0-61023')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'987697b6-d160-430b-b59d-e10451c75012', N'Admin', N'AppRole')
INSERT [dbo].[AspNetUserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Google', N'108801072818240148826', N'9dd5f491-19b4-478c-ba15-5706e207025d')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'987697b6-d160-430b-b59d-e10451c75012')
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Billing], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'Super Admin', NULL, N'admin@gmail.com', 1, N'ADRdeN4PWAQineITTLkwJe1Ke7WFSAKJTfoqg5De5+y5SkfC22Rx7lKoUnwQGwOqIw==', N'7cf16d87-2a20-4026-81df-efcf876d1945', NULL, 0, 0, NULL, 0, 0, N'admin@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Billing], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9dd5f491-19b4-478c-ba15-5706e207025d', N'MahmoudEllqany', NULL, N'ellqany@gmail.com', 1, NULL, N'c219ca0e-5976-458f-86c2-d3fa3a0c8625', N'01090345214', 0, 0, NULL, 0, 0, N'MahmoudEllqany')
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Billing], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'deb00662-8174-42f6-ac46-6efa428db09e', N'Mhmoud Ellqany', NULL, N'mahmoud10414498@yahoo.com', 1, N'AHfZ8SFrnk/wHN2CQVx4XaBVr7UGvaMg5dRbIFa3SqUE7as+9+spqA6vjCm4DAO7GA==', N'8865ac6a-af3a-4c2e-b499-5ddeb75005a1', NULL, 0, 0, NULL, 0, 0, N'mahmoud10414498@yahoo.com')
SET IDENTITY_INSERT [dbo].[CartLine] ON 

INSERT [dbo].[CartLine] ([CartLineID], [OrderID], [ProductID], [Quantity]) VALUES (1, 5, 2, 1)
INSERT [dbo].[CartLine] ([CartLineID], [OrderID], [ProductID], [Quantity]) VALUES (2, 6, 2, 1)
INSERT [dbo].[CartLine] ([CartLineID], [OrderID], [ProductID], [Quantity]) VALUES (3, 7, 2, 1)
INSERT [dbo].[CartLine] ([CartLineID], [OrderID], [ProductID], [Quantity]) VALUES (4, 8, 2, 1)
INSERT [dbo].[CartLine] ([CartLineID], [OrderID], [ProductID], [Quantity]) VALUES (5, 9, 2, 1)
SET IDENTITY_INSERT [dbo].[CartLine] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ContactId], [Name], [Email], [Subject], [Phone], [Massage]) VALUES (1, N'Super Admin', N'admin@gmail.com', N'Hello', N'01023456789', N'hi there!
how are you')
INSERT [dbo].[Contacts] ([ContactId], [Name], [Email], [Subject], [Phone], [Massage]) VALUES (2, N'Super Admin', N'admin@gmail.com', N'Hello', N'01023456789', N'hi there!
how are you')
INSERT [dbo].[Contacts] ([ContactId], [Name], [Email], [Subject], [Phone], [Massage]) VALUES (3, N'Super Admin', N'admin@gmail.com', N'Hello', N'01023456789', N'hi there!
how are you')
INSERT [dbo].[Contacts] ([ContactId], [Name], [Email], [Subject], [Phone], [Massage]) VALUES (4, N'Super Admin', N'admin@gmail.com', N'Hello', N'01023456789', N'hi there!
how are you')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (1, N'/Images/1193535180.jpg', N'Slider', N' ', N' ')
INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (2, N'/Images/2193941288.jpg', N'Slider', N' ', N' ')
INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (3, N'/Images/3194009928.jpg', N'Slider', N'Wellcome home', N'First Page')
INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (4, N'/Images/4194216361.jpg', N'Slider', N' ', N' ')
INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (5, N'/Images/custmoize194229052.png', N'Slider', N' ', N' ')
INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (6, N'/Images/home194245609.jpg', N'Slider', N' ', N' ')
INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (7, N'/Images/gift1192337345.png', N'Home', N'1', N'<h1 style="color:#554740; font-style:normal; margin-left:0px; margin-right:0px; text-align:center"><strong>How does it work? It&rsquo;s simple.</strong></h1>

<ol>
	<li><span style="font-size:18px"><span style="font-family:Arial,Helvetica,sans-serif">Choose the perfect Gift Set.</span></span></li>
	<li><span style="font-size:18px"><span style="font-family:Arial,Helvetica,sans-serif">Have it shipped to them or to yourself. Gift</span></span></li>
	<li><span style="font-size:18px"><span style="font-family:Arial,Helvetica,sans-serif">Gifting isn&rsquo;t a competition, but if it was you</span></span></li>
</ol>
')
INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (8, N'/Images/brush1192801265.png', N'Home', N'2', N'<h1 style="margin-left:0px; margin-right:0px; text-align:left"><strong>The restock box.</strong></h1>

<p style="text-align:left"><span style="font-size:14px"><span style="font-family:Arial,Helvetica,sans-serif">Four times a year (or whenever you want) we send a Restock Box so you never run out of anything you need to look, smell and feel your best.</span></span></p>
')
INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (9, N'/Images/home193013052.gif', N'Home', N'3', N'<h1 style="margin-left:0px; margin-right:0px; text-align:left"><strong>The Handsome Discount.</strong></h1>

<p style="text-align:left"><span style="font-size:16px">the more you buy, the more you save. Add two or more products and unlock big savings.</span></p>
')
INSERT [dbo].[Images] ([ImageId], [ImageURL], [Category], [Title], [Description]) VALUES (10, N'/Images/home6193044909.png', N'Home', N'4', N'<p>adqweqwe</p>
')
SET IDENTITY_INSERT [dbo].[Images] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [UserId], [Country], [City], [State], [Zip], [Line1], [Line2], [Line3], [RegisteratedDate], [RenewDate], [Baid], [GiftWrap], [Shipped]) VALUES (2, N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'Egypt', N'Cairo', N'KFS', NULL, N'stqwe', NULL, NULL, CAST(N'2019-09-05T10:23:54.760' AS DateTime), CAST(N'2019-10-05T10:23:54.760' AS DateTime), 0, 1, 0)
INSERT [dbo].[Orders] ([OrderID], [UserId], [Country], [City], [State], [Zip], [Line1], [Line2], [Line3], [RegisteratedDate], [RenewDate], [Baid], [GiftWrap], [Shipped]) VALUES (3, N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'Egypt', N'Cairo', N'KFS', NULL, N'stqwe', NULL, NULL, CAST(N'2019-09-05T10:49:19.430' AS DateTime), CAST(N'2019-10-05T10:49:19.430' AS DateTime), 0, 0, 0)
INSERT [dbo].[Orders] ([OrderID], [UserId], [Country], [City], [State], [Zip], [Line1], [Line2], [Line3], [RegisteratedDate], [RenewDate], [Baid], [GiftWrap], [Shipped]) VALUES (4, N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'Egypt', N'Cairo', N'KFS', NULL, N'stqwe', NULL, NULL, CAST(N'2019-09-05T10:51:04.323' AS DateTime), CAST(N'2019-10-05T10:51:04.323' AS DateTime), 0, 0, 0)
INSERT [dbo].[Orders] ([OrderID], [UserId], [Country], [City], [State], [Zip], [Line1], [Line2], [Line3], [RegisteratedDate], [RenewDate], [Baid], [GiftWrap], [Shipped]) VALUES (5, N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'Egypt', N'Cairo', N'KFS', NULL, N'stqwe', NULL, NULL, CAST(N'2019-09-05T10:57:41.043' AS DateTime), CAST(N'2019-10-05T10:57:41.043' AS DateTime), 0, 0, 0)
INSERT [dbo].[Orders] ([OrderID], [UserId], [Country], [City], [State], [Zip], [Line1], [Line2], [Line3], [RegisteratedDate], [RenewDate], [Baid], [GiftWrap], [Shipped]) VALUES (6, N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'Egypt', N'Cairo', N'KFS', NULL, N'stqwe', NULL, NULL, CAST(N'2019-09-05T17:19:07.737' AS DateTime), CAST(N'2019-10-05T17:19:07.737' AS DateTime), 0, 0, 0)
INSERT [dbo].[Orders] ([OrderID], [UserId], [Country], [City], [State], [Zip], [Line1], [Line2], [Line3], [RegisteratedDate], [RenewDate], [Baid], [GiftWrap], [Shipped]) VALUES (7, N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'Egypt', N'Cairo', N'KFS', NULL, N'stqwe', NULL, NULL, CAST(N'2019-09-05T17:36:16.087' AS DateTime), CAST(N'2019-10-05T17:36:16.087' AS DateTime), 0, 0, 0)
INSERT [dbo].[Orders] ([OrderID], [UserId], [Country], [City], [State], [Zip], [Line1], [Line2], [Line3], [RegisteratedDate], [RenewDate], [Baid], [GiftWrap], [Shipped]) VALUES (8, N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'Egypt', N'Cairo', N'KFS', NULL, N'stqwe', NULL, NULL, CAST(N'2019-09-05T17:39:07.080' AS DateTime), CAST(N'2019-10-05T17:39:07.080' AS DateTime), 0, 0, 0)
INSERT [dbo].[Orders] ([OrderID], [UserId], [Country], [City], [State], [Zip], [Line1], [Line2], [Line3], [RegisteratedDate], [RenewDate], [Baid], [GiftWrap], [Shipped]) VALUES (9, N'998659f3-774c-4d17-a19b-7a8f5cdee827', N'Egypt', N'Cairo', N'Giza', NULL, N'Giza', NULL, NULL, CAST(N'2019-09-06T09:47:14.063' AS DateTime), CAST(N'2019-10-06T09:47:14.063' AS DateTime), 1, 0, 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Category], [Description], [Name], [Price], [ImageUrl]) VALUES (1, N'Starter Set', N'<ul>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px">Executive Handle (1 ct)</span></span></li>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px">Post Shave Dew Trial Size (1 oz)</span></span></li>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px">Shave Butter Trial Size (1 oz)</span></span></li>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px">Prep Scrub Trial (1 oz</span></span></li>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px">Razor Cartridges (2 pk)</span></span></li>
</ul>
', N'The Ultimate Shave Starter Set', CAST(15.00 AS Decimal(18, 2)), N'/Images/account1193144163.png')
INSERT [dbo].[Products] ([ProductID], [Category], [Description], [Name], [Price], [ImageUrl]) VALUES (2, N'Starter Set', N'<ul>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px"><strong>Hydrating Shampoo Trial Size (1 fl oz)</strong></span></span></li>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px"><strong>Body Cleanser Trial Size (1 fl oz)</strong></span></span></li>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px"><strong>Daily Face Cleanser Trial Size (1 fl oz)</strong></span></span></li>
</ul>
', N'The Shower Starter Set', CAST(21.00 AS Decimal(18, 2)), N'/Images/pro2193910525.png')
INSERT [dbo].[Products] ([ProductID], [Category], [Description], [Name], [Price], [ImageUrl]) VALUES (3, N'Starter Set', N'<ul>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px">Toothbrush (1 brush)</span></span></li>
	<li><span style="font-family:Arial,Helvetica,sans-serif"><span style="font-size:18px">Toothpaste Trial Size (1 oz)</span></span></li>
</ul>
', N'The Oral Care Starter Set', CAST(25.00 AS Decimal(18, 2)), N'/Images/pro3194035280.png')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 9/7/2019 2:41:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 9/7/2019 2:41:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 9/7/2019 2:41:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 9/7/2019 2:41:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 9/7/2019 2:41:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 9/7/2019 2:41:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_Shipped]  DEFAULT ((0)) FOR [Shipped]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CartLine]  WITH CHECK ADD  CONSTRAINT [FK_CartLine_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartLine] CHECK CONSTRAINT [FK_CartLine_Orders]
GO
ALTER TABLE [dbo].[CartLine]  WITH CHECK ADD  CONSTRAINT [FK_CartLine_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartLine] CHECK CONSTRAINT [FK_CartLine_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AspNetUsers]
GO
USE [master]
GO
ALTER DATABASE [ClupStore] SET  READ_WRITE 
GO
