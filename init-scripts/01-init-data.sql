-- Initial data for Diabetes Monitoring System
-- This script will run automatically when PostgreSQL container starts

-- Insert sample roles
INSERT INTO "AppRoles" ("Id", "Name") VALUES 
('1', 'Patient'),
('2', 'Doctor')
ON CONFLICT ("Id") DO NOTHING;

-- Insert sample users (doctors)
INSERT INTO "AppUsers" ("Id", "UserName", "Email", "PasswordHash", "FirstName", "LastName", "Gender", "BirthDate", "PhoneNumber", "AppRoleId", "CreatedDate", "UpdatedDate") VALUES 
('1', 'dr.smith', 'dr.smith@hospital.com', '$2a$11$example_hash_here', 'John', 'Smith', 1, '1980-05-15', '+1234567890', '2', NOW(), NOW()),
('2', 'dr.johnson', 'dr.johnson@hospital.com', '$2a$11$example_hash_here', 'Sarah', 'Johnson', 2, '1985-08-22', '+1234567891', '2', NOW(), NOW())
ON CONFLICT ("Id") DO NOTHING;

-- Insert sample patients
INSERT INTO "AppUsers" ("Id", "UserName", "Email", "PasswordHash", "FirstName", "LastName", "Gender", "BirthDate", "PhoneNumber", "AppRoleId", "CreatedDate", "UpdatedDate") VALUES 
('3', 'patient1', 'patient1@email.com', '$2a$11$example_hash_here', 'Alice', 'Brown', 2, '1990-03-10', '+1234567892', '1', NOW(), NOW()),
('4', 'patient2', 'patient2@email.com', '$2a$11$example_hash_here', 'Bob', 'Wilson', 1, '1988-12-05', '+1234567893', '1', NOW(), NOW())
ON CONFLICT ("Id") DO NOTHING;

-- Insert sample symptoms
INSERT INTO "Symptoms" ("Id", "Name", "Description") VALUES 
('1', 'Frequent Urination', 'Need to urinate more often than usual'),
('2', 'Increased Thirst', 'Feeling very thirsty and drinking more fluids'),
('3', 'Fatigue', 'Feeling tired and lacking energy'),
('4', 'Blurred Vision', 'Difficulty seeing clearly'),
('5', 'Slow Healing', 'Cuts and wounds take longer to heal')
ON CONFLICT ("Id") DO NOTHING; 