alter table book add pagesamount integer not null;
alter table librarycards_books add returned varchar(1) not null;

drop table students_teachers;
drop table librarycards_students;
drop table librarycards_teachers;

create table studentgroup(
	id serial PRIMARY KEY,
	groupname varchar(20) not null,
	curator_id integer references teacher(id)
);

create table studentgroupteachers(
	id serial PRIMARY KEY,
	studentgroup_id integer references studentgroup(id),
	teacher_id integer references teacher(id),
	subject varchar(100) not null
);

alter table student add studentgroup_id integer not null references studentgroup(id);
alter table student add librarycard_id integer references librarycard(id);

alter table librarycard drop column registered;
alter table librarycard add column registrationDate TIMESTAMP WITHOUT TIME ZONE NOT NULL;
alter table librarycard drop column responsible_librarian_id;
alter table librarycard add column responsiblelibrarian_id integer references librarian(id);

alter table teacher add column librarycard_id integer references librarycard(id);