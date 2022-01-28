ALTER TABLE contributors
ADD CONSTRAINT FK_contributors_address
FOREIGN KEY (address_id) REFERENCES address(id);