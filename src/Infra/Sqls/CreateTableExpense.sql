CREATE TYPE payment_type AS ENUM ('Cash', 'CreditCard', 'DebitCard');

CREATE TABLE expenses (
                          id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
                          title TEXT NOT NULL,
                          description TEXT,
                          movement_at TIMESTAMP NOT NULL,
                          amount DECIMAL(10,2) NOT NULL,
                          payment payment_type NOT NULL
);


INSERT INTO expenses (title, description, movement_at, amount, payment)
VALUES ('Compra de insumos', 'Compra de fertilizantes para a safra', '2024-02-07 10:30:00', 1500.50, 'Cash');

