-- Create database with UTF-8 support
CREATE DATABASE IF NOT EXISTS diagramdb
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_general_ci;

-- Select the database
USE diagramdb;

-- Create employees table
CREATE TABLE IF NOT EXISTS employees (
  Id               INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Name             VARCHAR(100) NOT NULL,
  ParentId         INT NULL,
  FOREIGN KEY (ParentId) REFERENCES employees(Id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Insert sample organizational hierarchy data
INSERT INTO employees (Name, ParentId)
VALUES
('CEO', NULL),
('VP Engineering', 1),
('VP Sales', 1),
('Engineering Lead', 2),
('Sales Manager', 3),
('Developer 1', 4),
('Developer 2', 4),
('Sales Rep 1', 5),
('Sales Rep 2', 5);