DROP TABLE IF EXISTS "public"."testresult";
-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: indices, triggers. Do not use it as a backup.

-- Table Definition
CREATE TABLE "public"."testresult" (
    "id" SERIAL,
    "name" bpchar NOT NULL,
    "source" bpchar NOT NULL,
    "created" timestamp DEFAULT now(),
    "updated" timestamp DEFAULT now(),
    PRIMARY KEY ("id")
);

