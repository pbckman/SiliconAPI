SET IDENTITY_INSERT [dbo].[Courses] ON
INSERT INTO [dbo].[Courses] ([Id], [Title], [Author], [OriginalPrice], [DiscountPrice], [Hours],) VALUES (1, N'Frontend Development')
INSERT INTO [dbo].[Courses] ([Id], [CategoryName]) VALUES (2, N'App Development')
INSERT INTO [dbo].[Courses] ([Id], [CategoryName]) VALUES (3, N'Pyhton')
INSERT INTO [dbo].[Courses] ([Id], [CategoryName]) VALUES (4, N'HTML & CSS')
INSERT INTO [dbo].[Courses] ([Id], [CategoryName]) VALUES (5, N'Game Development')
SET IDENTITY_INSERT [dbo].[Categories] OFF