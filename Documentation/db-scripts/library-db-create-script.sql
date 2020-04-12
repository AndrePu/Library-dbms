
CREATE TABLE publishinghouse(
	id serial PRIMARY KEY,
	name VARCHAR (100) NOT NULL
);

CREATE TABLE author(
	id serial PRIMARY KEY,
	firstname VARCHAR (50),
	lastname VARCHAR (50)
);

CREATE TABLE authors_publishinghouses(
	id serial PRIMARY KEY,
	author_id INTEGER REFERENCES author(id),
	publishinghouse_id integer REFERENCES publishinghouse(id)
);

CREATE TABLE book(
	id serial PRIMARY KEY,
	name VARCHAR (50) NOT NULL,
	description VARCHAR(500),
	author_id integer REFERENCES author(id)
);

create table librarian(
	id serial primary key,
	firstname VARCHAR (50),
	lastname VARCHAR (50)	
);

create table librarycard(
	id serial primary key,
	registered TIMESTAMP WITHOUT TIME ZONE NOT NULL,
	responsible_librarian_id integer references librarian(id)
);

create table librarycards_books(
	id serial PRIMARY KEY,
	book_id INTEGER REFERENCES book(id),
	librarycard_id integer REFERENCES librarycard(id)
);

create table student(
	id serial PRIMARY KEY,
	firstname VARCHAR (50),
	lastname VARCHAR (50)	
);

create table teacher(
	id serial PRIMARY KEY,
	firstname VARCHAR (50),
	lastname VARCHAR (50)
);

CREATE TABLE students_teachers(
	id serial PRIMARY KEY,
	student_id INTEGER REFERENCES student(id),
	teacher_id integer REFERENCES teacher(id)
);

create table librarycards_teachers(
	id serial primary key,
	librarycard_id integer references librarycard(id),
	teacher_id integer references teacher(id)
);

create table librarycards_students(
	id serial primary key,
	librarycard_id integer references librarycard(id),
	student_id integer references student(id)
);
