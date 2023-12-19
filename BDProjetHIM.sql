
-- Creation de DB
CREATE DATABASE Hopital_CS;
GO
USE Hopital_Cs;
GO

--Creation table Patient
CREATE TABLE Patients (
    id INT PRIMARY KEY IDENTITY,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    age INT NOT NULL,
    adresse VARCHAR(100),
    telephone VARCHAR(20)
);

-- Creation table Visites
CREATE TABLE Visites (
    id INT PRIMARY KEY IDENTITY,
    patientid INT,
    datevisite DATETIME,
    medecin VARCHAR(50),
    numsalle INT,
    tarif decimal(10,2),
    FOREIGN KEY (patientid) REFERENCES Patients(id)
);

-- Creation table Authentification
CREATE TABLE Authentification (

    login VARCHAR(50) PRIMARY KEY,
    password VARCHAR(50) NOT NULL,
    nom VARCHAR(50) NOT NULL,
    metier INT NOT NULL CHECK (metier IN (0, 1, 2)),
	UNIQUE (nom)
);


-- Insertion table Patients
INSERT INTO Patients (nom, prenom, age, adresse, telephone)
VALUES
    ('Melloul', 'Jacky', 35, '101 rue St5', '6654322'),
    ('Gros-du-bois', 'Thomas', 23, '456 rue St1', '5555678'),
    ('Diop', 'Abdoulaye', 22, '789 rue St2', '5559876'),
    ('Sissoko', 'Samba', 25, '101 rue St3', '5554321'),
    ('Bob', 'David', 28, '202 rue St4', '5558765');


	-- Insertion table Visites
INSERT INTO Visites (patientid, datevisite, medecin, numsalle, tarif)
VALUES
    (1, GETDATE(), 'Dr. Messi', 1, 23),
    (2, GETDATE(), 'Dr. Ronaldo', 2, 23),
    (3, GETDATE(), 'Dr. lampard', 1, 23),
    (4, GETDATE(), 'Dr. Foden', 2, 23),
    (5, GETDATE(), 'Dr. Gardiola', 2, 23);


	-- Insertion table Authentication
INSERT INTO Authentification (login, password, nom, metier)
VALUES
    ('secretaria_login', 'secretary_password', 'Sophie', 0),
    ('docteur1_login', 'docteur1_password', 'Macron', 1),
    ('docteur2_login', 'docteur_password', 'Delbot', 2);
