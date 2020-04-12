
select * from student where lastname like 'Т%ко';

select student.id as student_id, student.firstname, student.lastname, sum(pagesamount) pagesread from student inner join 
(select librarycards_books.librarycard_id as librarycard_id, librarycards_books.book_id as book_id, book.pagesamount as pagesamount from librarycards_books
inner join book on librarycards_books.book_id = book.id where librarycards_books.returned='y') as librarycard_history
on student.librarycard_id = librarycard_history.librarycard_id group by student.id;

select student.firstname, student.lastname, studentgroup.groupname from student
inner join studentgroup on student.studentgroup_id = studentgroup.id 
where groupname = 'ПС-17-1' OR groupname = 'ПС-17-2' order by lastname asc;
