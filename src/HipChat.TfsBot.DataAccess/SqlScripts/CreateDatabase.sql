CREATE DATABASE HipChat_TfsBot;
GO

USE [HipChat_TfsBot];
GO

CREATE TABLE [Room]
(
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[RoomId] [integer] NOT NULL UNIQUE,
	[AuthToken] [nvarchar] (128) NOT NULL,
	[Secret] [nvarchar] (256) NOT NULL
);
GO