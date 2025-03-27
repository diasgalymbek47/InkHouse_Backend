create database ink_house;

create table pictures
(
    id      serial
        primary key,
    name    varchar(255) not null,
    author  varchar(255) not null,
    params  varchar(255) not null,
    price   numeric      not null,
    country varchar      not null,
    image   text         not null
);

create table users
(
    id       serial primary key,
    login    varchar(255) not null unique,
    password varchar(255) not null
);