-- Tạo cơ sở dữ liệu
CREATE DATABASE IF NOT EXISTS ecm;
USE ecm;

-- Bảng loại linh kiện
CREATE TABLE categories (
    category_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description TEXT
);

-- Bảng nhà sản xuất
CREATE TABLE manufacturers (
    manufacturer_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    contact_info TEXT,
    address TEXT
);

-- Bảng linh kiện
CREATE TABLE components (
    component_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    category_id INT,
    manufacturer_id INT,
    quantity INT DEFAULT 0,
    unit VARCHAR(20),
    price DECIMAL(10, 2),
    location VARCHAR(50),
    note TEXT,
    FOREIGN KEY (category_id) REFERENCES categories(category_id),
    FOREIGN KEY (manufacturer_id) REFERENCES manufacturers(manufacturer_id)
);

-- Bảng phiếu nhập kho
CREATE TABLE imports (
    import_id INT AUTO_INCREMENT PRIMARY KEY,
    date DATE NOT NULL,
    supplier VARCHAR(100),
    note TEXT
);

-- Chi tiết phiếu nhập
CREATE TABLE import_details (
    import_id INT,
    component_id INT,
    quantity INT NOT NULL,
    unit_price DECIMAL(10, 2),
    PRIMARY KEY (import_id, component_id),
    FOREIGN KEY (import_id) REFERENCES imports(import_id),
    FOREIGN KEY (component_id) REFERENCES components(component_id)
);

-- Bảng phiếu xuất kho
CREATE TABLE exports (
    export_id INT AUTO_INCREMENT PRIMARY KEY,
    date DATE NOT NULL,
    receiver VARCHAR(100),
    note TEXT
);

-- Chi tiết phiếu xuất
CREATE TABLE export_details (
    export_id INT,
    component_id INT,
    quantity INT NOT NULL,
    unit_price DECIMAL(10, 2),
    PRIMARY KEY (export_id, component_id),
    FOREIGN KEY (export_id) REFERENCES exports(export_id),
    FOREIGN KEY (component_id) REFERENCES components(component_id)
);

-- Bảng người dùng (nếu cần)
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(20) DEFAULT 'staff' -- staff, admin
);
