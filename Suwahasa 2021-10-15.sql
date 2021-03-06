USE [Suwahasa]
GO
/****** Object:  Table [dbo].[BedTickets]    Script Date: 10/15/2021 12:59:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BedTickets](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EnteredByFk] [bigint] NOT NULL,
	[DateEntered] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[BookingFk] [bigint] NULL,
 CONSTRAINT [PK_BedTickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 10/15/2021 12:59:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HospitalFk] [bigint] NOT NULL,
	[PackageFk] [bigint] NULL,
	[DateCreated] [datetime] NULL,
	[TransportRequested] [bit] NOT NULL,
	[TransportDate] [datetime] NULL,
	[VehicleFk] [bigint] NULL,
	[DateAdmitted] [datetime] NULL,
	[DateDischarged] [datetime] NULL,
	[PaymentStatus] [nvarchar](max) NULL,
	[TransportApproved] [bit] NULL,
	[ReservationDate] [datetime] NULL,
	[UserFk] [bigint] NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CovidTestResults]    Script Date: 10/15/2021 12:59:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CovidTestResults](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NULL,
	[DateTested] [datetime] NULL,
	[Result] [nvarchar](max) NULL,
	[BookingFk] [bigint] NULL,
 CONSTRAINT [PK_PCRResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/15/2021 12:59:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HospitalFk] [bigint] NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Nic] [nvarchar](max) NULL,
	[DriversLicenseNumber] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[AddressLine1] [nvarchar](max) NULL,
	[AddressLine2] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
	[Province] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[Specialization] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hospitals]    Script Date: 10/15/2021 12:59:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospitals](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[Subcategory] [nvarchar](max) NULL,
	[AddressLine1] [nvarchar](max) NULL,
	[AddressLine2] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
	[Province] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[CovidPatientCount] [int] NULL,
	[DischargedCovidPatientCount] [int] NULL,
	[IcuBedCount] [int] NULL,
	[AvailableOxygen] [float] NULL,
	[WardDescription] [nvarchar](max) NULL,
	[SanitaryDetails] [nvarchar](max) NULL,
	[MealsDetails] [nvarchar](max) NULL,
	[ActiveDoctors] [int] NULL,
	[ActiveNurses] [int] NULL,
	[AvailableAmbulances] [int] NULL,
	[CostPerPatient] [float] NULL,
 CONSTRAINT [PK_Hospitals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 10/15/2021 12:59:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HospitalFk] [bigint] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_Packages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/15/2021 12:59:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BookingFk] [bigint] NOT NULL,
	[Amount] [float] NULL,
	[Method] [nvarchar](max) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/15/2021 12:59:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeFk] [bigint] NULL,
	[Age] [int] NULL,
	[AddressLine1] [nvarchar](max) NULL,
	[AddressLine2] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[Nic] [nvarchar](max) NULL,
	[ContactNumber] [nvarchar](max) NULL,
	[BloodGroup] [nvarchar](max) NULL,
	[ParentOrGuardian] [nvarchar](max) NULL,
	[EmergencyContact] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Province] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 10/15/2021 12:59:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HospitalFk] [bigint] NULL,
	[Category] [nvarchar](max) NULL,
	[DriverFk] [bigint] NULL,
	[Available] [bit] NOT NULL,
	[VehicleNumber] [nvarchar](max) NULL,
	[Make] [nvarchar](max) NULL,
	[Model] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [HospitalFk], [FirstName], [LastName], [Phone], [Email], [Nic], [DriversLicenseNumber], [Role], [AddressLine1], [AddressLine2], [City], [District], [Province], [PostalCode], [Specialization], [Active]) VALUES (1, 1, N'Janith', N'Perera', N'0711506979', N'jccandro@gmail.com', N'941552897V', N'941552897', N'Driver', N'42/c Horaketiya Road', N'Korathota', N'Kaduwela', N'Colombo', N'Western Province', N'10640', N'', 1)
INSERT [dbo].[Employees] ([Id], [HospitalFk], [FirstName], [LastName], [Phone], [Email], [Nic], [DriversLicenseNumber], [Role], [AddressLine1], [AddressLine2], [City], [District], [Province], [PostalCode], [Specialization], [Active]) VALUES (2, 1, N'Rukshani', N'Adikari', N'0712223514', N'rukshani@gmail.com', N'941552898V', N'941552898V', N'Doctor', N'Apsara', N'Kirikiththa', N'Weliweriya', N'Gampaha', N'Western Province', N'10650', N'Oncologist', 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Hospitals] ON 

INSERT [dbo].[Hospitals] ([Id], [Name], [Category], [Subcategory], [AddressLine1], [AddressLine2], [City], [District], [Province], [PostalCode], [Phone], [CovidPatientCount], [DischargedCovidPatientCount], [IcuBedCount], [AvailableOxygen], [WardDescription], [SanitaryDetails], [MealsDetails], [ActiveDoctors], [ActiveNurses], [AvailableAmbulances], [CostPerPatient]) VALUES (1, N'Nawaloka Hospitals PLC', N'Private', N'Hospital', N'23 H K Dharmadasa Mawatha', N'Deshamanya', N'Colombo 2', N'Colombo', N'Western Province', N'00200', N'0115 577 111', 100, 50, 50, 20, N'A ward is a room in a hospital which has beds for many people, often people who need similar treatment.', N'Safety precautions such as wearing a mask, maintaining social distancing, hand sanitizing.', N'Ensure the provision of all necessary nutrients thanks to varied and balanced meals.', 45, 25, 20, 3500)
INSERT [dbo].[Hospitals] ([Id], [Name], [Category], [Subcategory], [AddressLine1], [AddressLine2], [City], [District], [Province], [PostalCode], [Phone], [CovidPatientCount], [DischargedCovidPatientCount], [IcuBedCount], [AvailableOxygen], [WardDescription], [SanitaryDetails], [MealsDetails], [ActiveDoctors], [ActiveNurses], [AvailableAmbulances], [CostPerPatient]) VALUES (2, N'Asiri Hospital', N'Private', N'Hospital', N'181 ', N'Kirula Rd', N'Colombo 5', N'Colombo', N'Western Province', N'00500', N'0114 523 300', 1, 51, 10, 120, N'Room Description', N'Sanitary Details', N'Meals Details', 500, 600, 100, 5000)
INSERT [dbo].[Hospitals] ([Id], [Name], [Category], [Subcategory], [AddressLine1], [AddressLine2], [City], [District], [Province], [PostalCode], [Phone], [CovidPatientCount], [DischargedCovidPatientCount], [IcuBedCount], [AvailableOxygen], [WardDescription], [SanitaryDetails], [MealsDetails], [ActiveDoctors], [ActiveNurses], [AvailableAmbulances], [CostPerPatient]) VALUES (3, N'Asiri Surgical Hospital', N'Private', N'Hospital', N'21', N'Kirimandala Mawatha', N'Colombo', N'Colombo', N'Western Province', N'00500', N'0114 524 400', 120, 120, 120, 120, N'Room Description', N'Sanitary Details', N'Meals Details', 120, 120, 120, 120)
INSERT [dbo].[Hospitals] ([Id], [Name], [Category], [Subcategory], [AddressLine1], [AddressLine2], [City], [District], [Province], [PostalCode], [Phone], [CovidPatientCount], [DischargedCovidPatientCount], [IcuBedCount], [AvailableOxygen], [WardDescription], [SanitaryDetails], [MealsDetails], [ActiveDoctors], [ActiveNurses], [AvailableAmbulances], [CostPerPatient]) VALUES (4, N'Asiri Central Hospital', N'Private', N'Hospital', N'114', N'Norris Canal Rd', N'Colombo 1', N'Colombo', N'Western Province', N'01000', N'0114 665 500', 500, 200, 120, 120, N'Room Description', N'Sanitary Details', N'Meals Details', 120, 120, 120, 120)
INSERT [dbo].[Hospitals] ([Id], [Name], [Category], [Subcategory], [AddressLine1], [AddressLine2], [City], [District], [Province], [PostalCode], [Phone], [CovidPatientCount], [DischargedCovidPatientCount], [IcuBedCount], [AvailableOxygen], [WardDescription], [SanitaryDetails], [MealsDetails], [ActiveDoctors], [ActiveNurses], [AvailableAmbulances], [CostPerPatient]) VALUES (5, N'Healan Hospital', N'Private', N'Hospital', N'380', N'High Level Rd', N'Homagama', N'Colombo', N'Western Province', N'10124', N'0112 857 676', 100, 100, 100, 120, N'Room Description', N'Sanitary Details', N'Meals Details', 152, 121, 124, 110)
SET IDENTITY_INSERT [dbo].[Hospitals] OFF
GO
SET IDENTITY_INSERT [dbo].[Packages] ON 

INSERT [dbo].[Packages] ([Id], [HospitalFk], [Name], [Description], [Price]) VALUES (1, 1, N'Basic', N'Basic options', 5000)
INSERT [dbo].[Packages] ([Id], [HospitalFk], [Name], [Description], [Price]) VALUES (2, 1, N'Premium', N'Premium options', 8000)
SET IDENTITY_INSERT [dbo].[Packages] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [EmployeeFk], [Age], [AddressLine1], [AddressLine2], [City], [District], [PostalCode], [Nic], [ContactNumber], [BloodGroup], [ParentOrGuardian], [EmergencyContact], [Status], [Password], [Username], [Province], [FirstName], [LastName], [Email], [Type]) VALUES (1, NULL, 28, N'42/c', N'Horaketiya Road', N'Kaduwela', N'Colombo', N'10640', N'941552897V', N'0711506979', N'A-', N'Gamini Perera', N'0711506979', NULL, N'$2a$11$6vaNr00KolnMSSAhN7RvHuKd34ZT6kSQISF9dNmLfbdke3Zb7xBdW', N'janith', N'Western Province', N'Janith', N'Perera', N'jccandro@gmail.com', N'User')
INSERT [dbo].[Users] ([Id], [EmployeeFk], [Age], [AddressLine1], [AddressLine2], [City], [District], [PostalCode], [Nic], [ContactNumber], [BloodGroup], [ParentOrGuardian], [EmergencyContact], [Status], [Password], [Username], [Province], [FirstName], [LastName], [Email], [Type]) VALUES (2, NULL, 27, N'Apsara', N'Kirikiththa', N'Weliweriya', N'Gampaha', N'10650', N'951223895', N'0712223514', N'B+', N'Mother', N'0715552224', NULL, N'$2a$11$WQ3t7IB0CCcv05pagdD4Ve6sUjWLiqdMooAxX04RoV2cObpFAuunu', N'rukshani', N'Western Province', N'Rukshani', N'Adikari', N'rukshani@gmail.com', N'User')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Vehicles] ([Id], [HospitalFk], [Category], [DriverFk], [Available], [VehicleNumber], [Make], [Model], [Type]) VALUES (1, 1, N'Ambulance', 1, 0, N'WP 62-2012', N'Toyota', N'LH 123', N'Van')
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
ALTER TABLE [dbo].[BedTickets] ADD  CONSTRAINT [DF_BedTickets_DateEntered]  DEFAULT (getdate()) FOR [DateEntered]
GO
ALTER TABLE [dbo].[Bookings] ADD  CONSTRAINT [DF_Bookings_TransportApproved]  DEFAULT ((0)) FOR [TransportApproved]
GO
ALTER TABLE [dbo].[Vehicles] ADD  CONSTRAINT [DF_Vehicles_Available]  DEFAULT ((1)) FOR [Available]
GO
ALTER TABLE [dbo].[BedTickets]  WITH CHECK ADD  CONSTRAINT [FK_BedTickets_Booking] FOREIGN KEY([BookingFk])
REFERENCES [dbo].[Bookings] ([Id])
GO
ALTER TABLE [dbo].[BedTickets] CHECK CONSTRAINT [FK_BedTickets_Booking]
GO
ALTER TABLE [dbo].[BedTickets]  WITH CHECK ADD  CONSTRAINT [FK_BedTickets_Employees] FOREIGN KEY([EnteredByFk])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[BedTickets] CHECK CONSTRAINT [FK_BedTickets_Employees]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Hospitals] FOREIGN KEY([HospitalFk])
REFERENCES [dbo].[Hospitals] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Hospitals]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Packages] FOREIGN KEY([PackageFk])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Packages]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Users] FOREIGN KEY([UserFk])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Users]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Vehicles] FOREIGN KEY([VehicleFk])
REFERENCES [dbo].[Vehicles] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Vehicles]
GO
ALTER TABLE [dbo].[CovidTestResults]  WITH CHECK ADD  CONSTRAINT [FK_CovidTestResults_Bookings] FOREIGN KEY([BookingFk])
REFERENCES [dbo].[Bookings] ([Id])
GO
ALTER TABLE [dbo].[CovidTestResults] CHECK CONSTRAINT [FK_CovidTestResults_Bookings]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Hospitals] FOREIGN KEY([HospitalFk])
REFERENCES [dbo].[Hospitals] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Hospitals]
GO
ALTER TABLE [dbo].[Packages]  WITH CHECK ADD  CONSTRAINT [FK_Packages_Hospitals] FOREIGN KEY([HospitalFk])
REFERENCES [dbo].[Hospitals] ([Id])
GO
ALTER TABLE [dbo].[Packages] CHECK CONSTRAINT [FK_Packages_Hospitals]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Bookings] FOREIGN KEY([BookingFk])
REFERENCES [dbo].[Bookings] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Bookings]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Employees] FOREIGN KEY([EmployeeFk])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Employees]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Employees] FOREIGN KEY([DriverFk])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Employees]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Hospitals] FOREIGN KEY([HospitalFk])
REFERENCES [dbo].[Hospitals] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Hospitals]
GO
