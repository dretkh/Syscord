CREATE TABLE IF NOT EXISTS users
(
    id      UUID PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS user_requisites
(
    userId  UUID REFERENCES users (id),
    name    text NOT NULL,
    value   text,
    PRIMARY KEY (userId, name)
    );

CREATE INDEX IF NOT EXISTS fkey_user_requisites_userid ON user_requisites (userId);
CREATE INDEX IF NOT EXISTS user_requisites_name_value ON user_requisites (name, value);