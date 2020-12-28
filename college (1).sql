-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 28, 2020 at 10:31 PM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `college`
--

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `employeeID` int(10) NOT NULL,
  `emp_name` varchar(25) NOT NULL,
  `emp_username` varchar(25) NOT NULL,
  `emp_password` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`employeeID`, `emp_name`, `emp_username`, `emp_password`) VALUES
(1, 'employee1', 'playerone', 'senha'),
(2, 'employee1', 'playerone', 'senha'),
(3, 'employee2', 'playertwo', 'password');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `studentID` varchar(25) NOT NULL,
  `std_firstname` varchar(25) NOT NULL,
  `std_lastname` varchar(25) NOT NULL,
  `std_email` varchar(25) NOT NULL,
  `std_phone` varchar(25) NOT NULL,
  `std_program` varchar(25) NOT NULL,
  `std_joining_date` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`studentID`, `std_firstname`, `std_lastname`, `std_email`, `std_phone`, `std_program`, `std_joining_date`) VALUES
('A000000001', 'Student', 'Student', 'student@email.ca', '(000) 000 - 0000', 'Course', '2020-12-17'),
('A000000123', 'Tralala', 'Hehe', 'anotheremail@canadore.ca', '(111) 111 - 1111', 'something', '2020-12-30'),
('A00000054621', 'one', 'two', 'exemplo@exercicio.ca', '(000) 123 - 1234', 'Course', '2020-12-10'),
('A123456789', 'one', 'a;sldfja', 'afsdfa@dsafdslfa.ca', '123456789', 'Course', '2020-12-15'),
('A161568451', 'wabalabadubdub', 'Student', 'student@email.ca', '(000) 000 - 0000', 'Course', '2020-12-17'),
('aasdfasdf', 'Student', 'Student', 'student@email.ca', 'asdfa', 'Course', '2020-12-17'),
('asdfasdfas', 'fasdfasdf', 'asdfasdfasdf', 'sdfasdfasdfa', '(000) 000 - 0000', 'sdfadsfas', '2020-12-17');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`employeeID`),
  ADD KEY `employeeID` (`employeeID`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`studentID`),
  ADD KEY `studentID` (`studentID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `employeeID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
