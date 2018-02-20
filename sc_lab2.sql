CREATE SCHEMA `library_system` ;
Create table library_system.user
(
id int not null auto_increment,
fname varchar(255),
email varchar(255) unique,
pass varchar(255),
primary key(id)
);
create table library_system.artifact
(
id int not null auto_increment,
name varchar(255),
primary key(id)
);
create table library_system.genre
(
id int not null auto_increment,
name varchar(255),
primary key(id)
);
create table library_system.title
(
id int not null auto_increment,
name varchar(255),
quantity int,
isbn varchar(255),
primary key(id)
);
create table library_system.author
(
id int not null auto_increment,
name varchar(255),
primary key(id)
);
create table library_system.book
(
id int not null auto_increment,
publish_date date,
status varchar(255) not null,
batch_number varchar(255),
price int,
mode varchar(255),
title_id int,
author_id int,
genre_id int,
artifact_id int,
foreign key (title_id) references title(id),
foreign key (author_id) references author(id),
foreign key (genre_id) references genre(id),
foreign key (artifact_id) references artifact(id),
primary key(id)
);
create table library_system.admin
(
	id int not null auto_increment,
    email varchar(255) unique,
    pass varchar(255),
    primary key(id)
);
create table library_system.issue
(
	id int not null auto_increment,
    email varchar(255),
    title varchar(255),
    issue_date date,
    artifact_id int,
    foreign key (artifact_id) references artifact(id),
    primary key(id)
);
create table library_system.fine
(
	id int not null auto_increment,
    email varchar(255),
    fin int,
    primary key(id)
);