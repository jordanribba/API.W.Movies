select * from categories;

INSERT INTO categories (Id, Name, CreatedDate, ModifiedDate) VALUES
(5, 'Documentals', GETDATE(), NULL),
(6, 'Suspense', GETDATE(), NULL);

SET IDENTITY_INSERT categories OFF;

