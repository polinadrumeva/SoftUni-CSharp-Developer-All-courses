
ALTER TABLE dvo_Minions ADD TownId int;
ALTER TABLE dvo_Minions
ADD CONSTRAINT fk_minions_towns FOREIGN KEY(TownId)
REFERENCES dvo_Towns(id);