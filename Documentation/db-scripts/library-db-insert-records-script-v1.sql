insert into publishinghouse(name) values('АБАЛАКАМАГА');
insert into author(firstname, lastname) values('Всеволод', 'Нестайко');
insert into authors_publishinghouses(author_id, publishinghouse_id) values(1, 1);

insert into book(name, description, author_id, pagesamount)
values('Тореадори з Васюківки', 'Книга про двох хлопчаків', 1, 578);

insert into book(name, description, author_id, pagesamount)
values('Пригоди лісових звірят', 'Книга про ліс', 1, 123);

insert into book(name, description, author_id, pagesamount)
values('Нові пригоди лісових звірят', 'Книга про новий ліс', 1, 256);


insert into librarian(firstname, lastname) values('Алла', 'Афанасьева');

insert into librarycard(registrationdate, responsiblelibrarian_id) values('13-nov-18', 1);
insert into librarycard(registrationdate, responsiblelibrarian_id) values('13-nov-19', 1);
insert into librarycard(registrationdate, responsiblelibrarian_id) values('13-nov-01', 1);

insert into teacher(firstname, lastname, librarycard_id) values('Лидия', 'Бойко', 3);
insert into studentgroup(curator_id, groupname) values(1, 'ПС-17-1');
insert into studentgroup(curator_id, groupname) values(1, 'ПС-17-2');

insert into student(firstname, lastname, studentgroup_id, librarycard_id) values('Андрей', 'Пугач', 1, 1);
insert into student(firstname, lastname, studentgroup_id, librarycard_id) values('Ярослав', 'Семенец', 2, 2);
insert into student(firstname, lastname, studentgroup_id, librarycard_id) values('Яна', 'Терещенко', 1, null);
insert into student(firstname, lastname, studentgroup_id) values('Андрей', 'Троценко', 1);


insert into librarycards_books(book_id, librarycard_id, returned) values(1, 3, 'y');
insert into librarycards_books(book_id, librarycard_id, returned) values(2, 3, 'y');
insert into librarycards_books(book_id, librarycard_id, returned) values(3, 3, 'y');
insert into librarycards_books(book_id, librarycard_id, returned) values(2, 2, 'y');
insert into librarycards_books(book_id, librarycard_id, returned) values(1, 2, 'y');
insert into librarycards_books(book_id, librarycard_id, returned) values(3, 1, 'y');
insert into librarycards_books(book_id, librarycard_id, returned) values(2, 1, 'n');
insert into librarycards_books(book_id, librarycard_id, returned) values(1, 1, 'y');


