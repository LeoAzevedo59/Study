CREATE TYPE payment_type AS ENUM ('cash', 'credit_card', 'debit_card');

CREATE TABLE expenses (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    title TEXT NOT NULL,
    description TEXT,
    movement_at TIMESTAMP NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    payment payment_type NOT NULL
);