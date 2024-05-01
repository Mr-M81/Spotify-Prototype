Create DATABASE SPOTIFY
USE SPOTIFY

--Creating Customer Table
CREATE TABLE CUSTOMER_TABLE
(
CUSTOMER_ID INT IDENTITY(100,1) PRIMARY KEY,
FIRST_NAME VARCHAR(50) NOT NULL,
LAST_NAME VARCHAR(50)  NOT NULL,
EMAIL_ADDRESS VARCHAR(100) NOT NULL UNIQUE,
PHONE_NO VARCHAR(20) NOT NULL UNIQUE,
DATE_OF_BIRTH DATE NOT NULL,
PASSWORD VARCHAR(100) NOT NULL,
CHECK (EMAIL_ADDRESS LIKE '%@gmail.com%' or EMAIL_ADDRESS LIKE '%@yahoo.com%' or EMAIL_ADDRESS LIKE '%@icloud.com%' or EMAIL_ADDRESS LIKE '%outlook.com%'
AND len(PASSWORD) >= 8 
AND len(PHONE_NO) = 14)
)

--inserting in the Customer table 
CREATE PROCEDURE STORE_USER_DATA
(
@FIRST_NAME VARCHAR(50),
@LAST_NAME VARCHAR(50)  ,
@EMAIL_ADDRESS VARCHAR(100),
@PHONE_NO VARCHAR(20) ,
@DATE_OF_BIRTH DATE ,
@PASSWORD VARCHAR(100))
AS INSERT INTO CUSTOMER_TABLE VALUES(@FIRST_NAME,@LAST_NAME,@EMAIL_ADDRESS,@PHONE_NO,@DATE_OF_BIRTH,@PASSWORD)

--this procedure will be used to read into the database, and check if the user has logged in.
Create Procedure LOGIN_USER
(
@EMAIL_ADDRESS VARCHAR(100),
@PASSWORD VARCHAR(100))
AS
BEGIN
SELECT * FROM CUSTOMER_TABLE
WHERE EMAIL_ADDRESS = @EMAIL_ADDRESS AND PASSWORD = @PASSWORD
END

--Creating artist table
CREATE TABLE ARTIST_TABLE
(
ARTIST_ID INT IDENTITY(300,3) PRIMARY KEY,
ARTIST_FNAME VARCHAR(50) NOT NULL,
ARTIST_LNAME VARCHAR(50) NOT NULL,
ARTIST_PERFORMANCE_NAME VARCHAR(50) NOT NULL ,
ARTIST_AGE VARCHAR(50) NOT NULL,
ARTIST_DOB DATE NOT NULL,
ARTIST_MONTHLY_LISTENERS FLOAT DEFAULT 0,
NO_OF_FOLLOWERS INT NOT NULL DEFAULT 0
)

--Creating album table
CREATE TABLE ALBUM_TABLE
(
ALBUM_ID INT IDENTITY(200,2) PRIMARY KEY,
ALBUM_TITLE VARCHAR(50) NOT NULL UNIQUE,
ALBUM_REALSE_DATE DATE NOT NULL ,
ALBUM_GENRE VARCHAR(50) NOT NULL,
ARTIST_ID INT FOREIGN KEY REFERENCES ARTIST_TABLE(ARTIST_ID)
)

--Creating track table

CREATE TABLE TRACK_TABLE
(
TRACK_ID INT IDENTITY(400,2) PRIMARY KEY,
TRACK_TITLE VARCHAR(50) NOT NULL,
TRACK_LENGTH VARCHAR(8) NOT NULL,
ALBUM_ID INT FOREIGN KEY REFERENCES ALBUM_TABLE (ALBUM_ID) NOT NULL ,
ARTIST_ID INT FOREIGN KEY REFERENCES ARTIST_TABLE(ARTIST_ID) NOT NULL
)

--Creating playlist table
CREATE TABLE PLAYLIST_TABLE
(
PLAYLIST_ID INT IDENTITY(1,1) PRIMARY KEY,
NUMBER_OF_PLAYLISTS_CREATED INT NOT NULL,
NO_OF_SONGS INT DEFAULT 1,
CUSTOMER_ID INT FOREIGN KEY REFERENCES CUSTOMER_TABLE(CUSTOMER_ID),
)

--Creating the subscription table
CREATE TABLE SUBSCRIPTION_TABLE
(
SUBSCRIPTION_ID INT identity (1,1) PRIMARY KEY,
SUBSCRIPTION_NAME  VARCHAR(50) DEFAULT 'Standard',
SUBSCRIPTION_START_DATE DATETIME NOT NULL,
SUBSCRIPTION_START_END_ DATETIME NOT NULL,
SUBSCRIPTION_PRICE VARCHAR(255) NOT NULL,
CUSTOMER_ID INT FOREIGN KEY REFERENCES CUSTOMER_TABLE( CUSTOMER_ID)
)

--This procedure will let the user subscribe to a music package.
CREATE PROCEDURE SUBSCRIBE_USER
(
@SUBSCRIPTION_NAME VARCHAR(50),
@SUBSCRIPTION_START_DATE DATE ,
@SUBSCRIPTION_START_END_ DATE,
@SUBSCRIPTION_PRICE VARCHAR(255),
@CUSTOMER_ID INT
 )
AS INSERT INTO SUBSCRIPTION_TABLE VALUES(@SUBSCRIPTION_NAME,@SUBSCRIPTION_START_DATE,@SUBSCRIPTION_START_END_,@SUBSCRIPTION_PRICE,@CUSTOMER_ID)

--Sql Trigger that will check if the user attempts to subscribe to the same package.
CREATE TRIGGER CheckSubscriptionUpdate
        ON SUBSCRIPTION_TABLE
        FOR UPDATE
        AS
        BEGIN
            IF UPDATE(SUBSCRIPTION_NAME)
            BEGIN
                DECLARE @CurrentSubscription VARCHAR(50)
                DECLARE @NewSubscription VARCHAR(50)
                DECLARE @CustomerID INT

                SELECT @CurrentSubscription = SUBSCRIPTION_NAME
                FROM INSERTED

                SELECT @NewSubscription = SUBSCRIPTION_NAME
                FROM DELETED

                SELECT @CustomerID = CUSTOMER_ID
                FROM INSERTED

                IF (@CurrentSubscription = @NewSubscription)
                BEGIN
                    RAISERROR('Cannot upgrade to the same subscription package.', 16, 1)
                    ROLLBACK TRANSACTION
                    RETURN
                   
                END
            END
        END

CREATE TABLE REVIEW_TABLE
(
REVIEW_ID INT identity(1,1)  PRIMARY KEY,
RATING INT ,
REVIEW_TEXT VARCHAR(255),
REVIEWD_SONG VARCHAR(255),
CUSTOMER_ID INT FOREIGN KEY REFERENCES CUSTOMER_TABLE(CUSTOMER_ID),
TRACK_ID INT FOREIGN KEY REFERENCES TRACK_TABLE (TRACK_ID)
)
select * from CUSTOMER_TABLE
SELECT * FROM SUBSCRIPTION_TABLE

--displays the artists via their performance name
Create View Name_of_artist
as 
Select ARTIST_PERFORMANCE_NAME
from ARTIST_TABLE

Select * from Name_of_artist
--inserting into the Artist table
INSERT INTO ARTIST_TABLE (ARTIST_FNAME, ARTIST_LNAME, ARTIST_PERFORMANCE_NAME, ARTIST_AGE, ARTIST_DOB, ARTIST_MONTHLY_LISTENERS, NO_OF_FOLLOWERS)
VALUES
    ('Kendrick', 'Lamar', 'Kendrick Lamar', '34', '1987-06-17', 3000000, 750000),
    ('Eminem', 'Mathers', 'Eminem', '48', '1972-10-17', 4500000, 1200000),
    ('Black', 'Coffee', 'Black Coffee', '45', '1976-03-11', 1700000, 500000),
    ('Kabza', 'De Small', 'Kabza De Small', '30', '1992-11-27', 2000000, 600000),
     ('Drake', 'Graham', 'Drake', '35', '1986-10-24', 4000000, 1000000),
	 ('Abel','Makkonen','The Weekends','33','1990-02-16',107507345,20000000),
	 ('Bryson','Djuan','Bryson Tiller','30','1993-01-02',64003943,78987234),
	 ('Adam', 'Levine', 'Maroon 5','34','1989-03-23',7654323,3453234);

--inserting into the album table
INSERT INTO ALBUM_TABLE (ALBUM_TITLE, ALBUM_REALSE_DATE, ALBUM_GENRE, ARTIST_ID)
VALUES ('Nothing Was the Same', '2013-09-24', 'Hip-Hop', 312),
('Views', '2016-04-29', 'Hip-Hop', 312),
('If Youre Reading This Its Too Late', '2015-02-13', 'Hip-Hop', 312),
('Scorpion', '2018-06-29', 'Hip-Hop', 312),
('Africa Rising', '2012-11-17', 'House', 306),
('Pieces of Me', '2015-05-05', 'House', 306),
('I Am the King of Amapiano', '2020-06-26', 'Amapiano', 309),
('The Return of Scorpion Kings', '2019-11-29', 'Amapiano', 309),
('Pretty Girls Love Amapiano', '2019-12-06', 'Amapiano', 309),
('Avenue Sounds', '2016-12-02', 'Amapiano', 309),
('To Pimp a Butterfly', '2015-03-15', 'Hip-Hop', 300),
('Good Kid, M.A.A.D City', '2012-10-22', 'Hip-Hop', 300),
('The Marshall Mathers LP', '2000-05-23', 'Hip-Hop', 303),
('The Slim Shady LP', '1999-02-23', 'Hip-Hop', 303),
('After Hours','2020-03-20','POP',315),
('Starboy','2016-11-25','POP',315),
('Songs About Jane','2002-06-25','POP',321),
('Trapsoul','2015-10-2','RnB',318),
('Anniversary','2020-10-2','RnB',318),
('Dawn FM','2022-01-07','Pop',315);


INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('God''s Plan', '5:04', 200, 312),
  ('Furthest Thing', '4:27', 200, 312),
  ('Started From the Bottom', '2:53', 200, 312),
  ('Wu-Tang Forever', '3:37', 200, 312),
  ('Own It', '4:11', 200, 312),
  ('Worst Behavior', '4:30', 200, 312),
  ('From Time (feat. Jhene Aiko)', '5:22', 200, 312),
  ('Hold On We''re Going Home (feat. Majid Jordan)', '3:51', 200, 312);

-- Songs for 'Views' (ALBUM_ID: 202)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Keep the Family Close', '5:28', 202, 312),
  ('9', '4:15', 202, 312),
  ('U With Me?', '4:57', 202, 312),
  ('Feel No Ways', '4:00', 202, 312),
  ('Hype', '3:29', 202, 312),
  ('Weston Road Flows', '4:13', 202, 312),
  ('Redemption', '5:34', 202, 312),
  ('One Dance (feat. Wizkid & Kyla)', '2:53', 202, 312);

-- Songs for 'If You're Reading This It's Too Late' (ALBUM_ID: 204)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Legend', '4:01', 204, 312),
  ('Energy', '3:01', 204, 312),
  ('10 Bands', '2:57', 204, 312),
  ('Know Yourself', '4:35', 204, 312),
  ('No Tellin', '5:12', 204, 312),
  ('Used To', '4:28', 204, 312),
  ('6 Man', '2:47', 204, 312),
  ('Now & Forever', '4:41', 204, 312);

-- Songs for 'Scorpion' (ALBUM_ID: 206)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Survival', '2:16', 206, 312),
  ('Nonstop', '3:58', 206, 312),
  ('Elevate', '3:04', 206, 312),
  ('Emotionless', '5:02', 206, 312),
  ('Tusan Leather', '3:18', 206, 312),
  ('I''m Upset', '3:34', 206, 312),
  ('8 Out Of 10', '3:15', 206, 312),
  ('Mob Ties', '3:25', 206, 312);

-- Songs for 'Africa Rising' (ALBUM_ID: 208)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('We Dance Again', '7:24', 208, 306),
  ('Drive', '5:32', 208, 306),
  ('Im Fallin', '4:58', 208, 306),
  ('Safari Serenade', '5:12', 208, 306),
  ('Jungle Beat', '4:41', 208, 306),
  ('Savannah Dreams', '6:10', 208, 306),
  ('Spirit of the Desert', '5:28', 208, 306),
  ('Tribal Rhythms', '4:20', 208, 306);

-- Songs for 'Pieces of Me' (ALBUM_ID: 210)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Pieces of Me', '6:24', 210, 306),
  ('Deep in My Soul', '5:42', 210, 306),
  ('House Party', '4:58', 210, 306),
  ('Groove Motion', '5:12', 210, 306),
  ('Funky Beats', '4:41', 210, 306),
  ('Soulful Journey', '6:10', 210, 306),
  ('Melodies of Love', '5:28', 210, 306),
  ('Dancefloor Delight', '4:20', 210, 306);

-- Songs for 'I Am the King of Amapiano' (ALBUM_ID: 212)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('eMcimbini', '6:47', 212, 309),
  ('Nana Thula', '7:18', 212, 309),
  ('Abalele', '6:54', 212, 309),
  ('Asibe Happy', '7:39', 212, 309),
  ('Feel the Bass', '4:41', 212, 309),
  ('Party All Night', '6:10', 212, 309),
  ('Amapiano Grooves', '5:28', 212, 309),
  ('Dancefloor Anthem', '4:20', 212, 309);

-- Songs for 'The Return of Scorpion Kings' (ALBUM_ID: 214)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Scorpion Kings Unleashed', '6:24', 214, 309),
  ('Amapiano Invasion', '5:42', 214, 309),
  ('King of the Beat', '4:58', 214, 309),
  ('Scorpion Dance', '5:12', 214, 309),
  ('Melodies of Amapiano', '4:41', 214, 309),
  ('Rhythm of the Night', '6:10', 214, 309),
  ('Amapiano Vibes', '5:28', 214, 309),
  ('Scorpion Party', '4:20', 214, 309);

-- Songs for 'Pretty Girls Love Amapiano' (ALBUM_ID: 216)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Pretty Girls Intro', '2:18', 216, 309),
  ('Amapiano Love', '4:05', 216, 309),
  ('Dance with Me', '3:54', 216, 309),
  ('Sunset Romance', '4:32', 216, 309),
  ('Feel the Beat', '3:21', 216, 309),
  ('Party in Paradise', '4:47', 216, 309),
  ('Midnight Serenade', '3:59', 216, 309),
  ('Pretty Girls Outro', '1:36', 216, 309);

-- Songs for 'Avenue Sounds' (ALBUM_ID: 218)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Avenue Beats', '4:32', 218, 309),
  ('House Grooves', '3:54', 218, 309),
  ('Party Vibes', '4:05', 218, 309),
  ('Nightlife Sensation', '3:41', 218, 309),
  ('Feel the Energy', '4:18', 218, 309),
  ('Dancefloor Madness', '4:47', 218, 309),
  ('Beats of the Avenue', '3:59', 218, 309),
  ('Avenue Jam', '4:15', 218, 309);

-- Songs for 'To Pimp a Butterfly' (ALBUM_ID: 220)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Wesley''s Theory', '4:47', 220, 300),
  ('For Free? (Interlude)', '2:10', 220, 300),
  ('King Kunta', '3:54', 220, 300),
  ('Institutionalized', '4:31', 220, 300),
  ('These Walls', '5:00', 220, 300),
  ('u', '4:28', 220, 300),
  ('Alright', '3:39', 220, 300),
  ('Hood Politics', '4:52', 220, 300);

-- Songs for 'Good Kid, M.A.A.D City' (ALBUM_ID: 222)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Sherane a.k.a Master Splinter''s Daughter', '4:34', 222, 300),
  ('Bitch Don''t Kill My Vibe', '5:10', 222, 300),
  ('Backseat Freestyle', '3:32', 222, 300),
  ('The Art of Peer Pressure', '5:24', 222, 300),
  ('Money Trees (feat. Jay Rock)', '6:26', 222, 300),
  ('Poetic Justice (feat. Drake)', '5:00', 222, 300),
  ('m.A.A.d city (feat. MC Eiht)', '5:50', 222, 300),
  ('Swimming Pools (Drank)', '4:07', 222, 300);

-- Songs for 'The Marshall Mathers LP' (ALBUM_ID: 224)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Mocking Bird', '4:33', 224, 303),
  ('Superman(feat. Dina Rae)', '4:24', 224, 303),
  ('Stan (feat. Dido)', '6:44', 224, 303),
  ('The Way I Am', '4:50', 224, 303),
  ('The Real Slim Shady', '4:44', 224, 303),
  ('Remember Me? (feat. RBX & Sticky Fingaz)', '3:38', 224, 303),
  ('Criminal', '5:16', 224, 303),
  ('Kim', '6:17', 224, 303);

-- Songs for 'The Slim Shady LP' (ALBUM_ID: 226)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Kill You', '4:24', 226, 303),
  ('My Name Is', '4:28', 226, 303),
  ('Guilty Conscience (feat. Dr. Dre)', '3:19', 226, 303),
  ('Brain Damage', '3:46', 226, 303),
  ('Role Model', '3:25', 226, 303),
  ('Rock Bottom', '3:34', 226, 303),
  ('Just Don''t Give a F**k', '4:02', 226, 303),
  ('As the World Turns', '4:25', 226, 303);

-- Songs for 'After Hours' (ALBUM_ID: 228)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Starboy (feat. Daft Punk)', '3:50', 228, 315),
  ('Blinding Lights', '3:20', 228, 315),
  ('Save Your Tears', '3:31', 228, 315),
  ('Scared to Live', '3:11', 228, 315),
  ('Snowchild', '4:07', 228, 315),
  ('Escape from LA', '5:55', 228, 315),
  ('Heartless', '3:18', 228, 315),
  ('Faith', '4:43', 228, 315);

-- Songs for 'Starboy' (ALBUM_ID: 230)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Alone Again', '4:10', 230, 315),
  ('Party Monster', '4:09', 230, 315),
  ('False Alarm', '3:40', 230, 315),
  ('Reminder', '3:39', 230, 315),
  ('Rockin''', '3:52', 230, 315),
  ('Secrets', '4:25', 230, 315),
  ('True Colors', '3:26', 230, 315),
  ('Stargirl Interlude (feat. Lana Del Rey)', '1:51', 230, 315);

-- Songs for 'Songs About Jane' (ALBUM_ID: 232)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Payphone(feat. Wiz Khalifa)', '2:53', 232, 321),
  ('Girls Like You', '3:26', 232, 321),
  ('Memories', '3:01', 232, 321),
  ('She Will Be Loved', '4:17', 232, 321),
  ('Tangled', '3:18', 232, 321),
  ('The Sun', '4:12', 232, 321),
  ('Must Get Out', '3:59', 232, 321),
  ('Sunday Morning', '4:01', 232, 321);

-- Songs for 'Trapsoul' (ALBUM_ID: 234)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Intro (Difference)', '2:25', 234, 318),
  ('Let Em Know', '4:17', 234, 318),
  ('Exchange', '3:14', 234, 318),
  ('For However Long', '3:20', 234, 318),
  ('Don''t', '3:18', 234, 318),
  ('Open Interlude', '2:50', 234, 318),
  ('Ten Nine Fourteen', '4:32', 234, 318),
  ('The Sequence', '3:15', 234, 318);

-- Songs for 'Anniversary' (ALBUM_ID: 236)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Years Go By', '3:56', 236, 318),
  ('Always Forever', '3:58', 236, 318),
  ('I''m Ready for You', '3:43', 236, 318),
  ('Things Change', '3:59', 236, 318),
  ('Inhale', '3:57', 236, 318),
  ('Outta Time (feat. Drake)', '2:54', 236, 318),
  ('Keep Doing What You''re Doing', '3:59', 236, 318),
  ('Next to You (feat. Ruel)', '4:07', 236, 318);

-- Songs for 'Dawn FM' (ALBUM_ID: 238)
INSERT INTO TRACK_TABLE (TRACK_TITLE, TRACK_LENGTH, ALBUM_ID, ARTIST_ID)
VALUES
  ('Dawn FM', '0:59', 238, 315),
  ('The Trilogy (feat. Lil Wayne & SZA)', '4:42', 238, 315),
  ('Gasoline (feat. Takeoff)', '3:45', 238, 315),
  ('Die for You (feat. The Weeknd)', '4:08', 238, 315),
  ('Dawn FM Interlude', '0:55', 238, 315),
  ('Sad Hours', '3:22', 238, 315),
  ('Escape from Earth', '5:12', 238, 315),
  ('Blinding Lights', '3:20', 238, 315);


--THIS PROCEDURE WILL BE USED TO WRITE THE REVIEW INTO THE DATABASE.
Create Procedure Review 
@Rating iNT,
@REVIEW VARCHAR(255),
@REVIEWED_SONG VARCHAR(255),
@CUSTOMER_ID INT,
@TRACK_ID INT
AS
iNSERT INTO REVIEW_TABLE VALUES(@Rating,@REVIEW,@REVIEWED_SONG,@CUSTOMER_ID,@TRACK_ID)

--Playlist for gym playlist
CREATE VIEW GymPlaylist
AS
SELECT TOP 6 TRACK_TABLE.TRACK_TITLE,ALBUM_TITLE,TRACK_TABLE.TRACK_LENGTH FROM ALBUM_TABLE
INNER JOIN TRACK_TABLE
ON TRACK_TABLE.ALBUM_ID=ALBUM_TABLE.ALBUM_ID
WHERE ALBUM_GENRE='Hip-hop'
ORDER BY NEWID()

--Playlist that will provide the pop playlist
CREATE VIEW PopPlaylist
AS
SELECT TOP 6 TRACK_TABLE.TRACK_TITLE,ALBUM_TITLE,TRACK_TABLE.TRACK_LENGTH FROM ALBUM_TABLE
INNER JOIN TRACK_TABLE
ON TRACK_TABLE.ALBUM_ID=ALBUM_TABLE.ALBUM_ID
WHERE ALBUM_GENRE='Pop'
ORDER BY NEWID();

--playlist that will provide the lo fi playlist
CREATE VIEW LofiPlaylist
AS
SELECT TOP 6  TRACK_TABLE.TRACK_TITLE,ALBUM_TITLE,TRACK_TABLE.TRACK_LENGTH FROM ALBUM_TABLE
INNER JOIN TRACK_TABLE
ON TRACK_TABLE.ALBUM_ID=ALBUM_TABLE.ALBUM_ID
WHERE ALBUM_GENRE='Hip-hop' OR ALBUM_GENRE='Pop'
ORDER BY NEWID();

--playlist that will have the lifestyle playlist
CREATE VIEW LifeStyle_Playlist
AS
SELECT TOP 6  TRACK_TABLE.TRACK_TITLE,ALBUM_TITLE,TRACK_TABLE.TRACK_LENGTH FROM ALBUM_TABLE
INNER JOIN TRACK_TABLE
ON TRACK_TABLE.ALBUM_ID=ALBUM_TABLE.ALBUM_ID
WHERE ALBUM_GENRE = 'Amapiano' or ALBUM_GENRE = 'House' 
ORDER BY NEWID()

SELECT * FROM GymPlaylist
SELECT * FROM LofiPlaylist
SELECT * FROM LifeStyle_Playlist
SELECT * FROM PopPlaylist
---------------------------------------------------------------------------------------------------------------------------


