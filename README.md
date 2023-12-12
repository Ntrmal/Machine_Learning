# Truck Engine Efficiency Prediction with OBD Data and ML.NET

## Overview

Modern trucks are equipped with on-board diagnostic (OBD) systems that continuously monitor engine performance, providing real-time data on various parameters such as engine speed, coolant temperature, and fuel consumption. This project proposes a machine learning-based approach to analyze OBD data from a truck engine to predict its efficiency. The solution is implemented as a Blazor web application built using C# and ML.NET.

## Features

- **Data Collection:** Collects OBD data from the truck's engine, including parameters like engine speed, load, coolant temperature, fuel consumption, and battery voltage.

- **Data Preprocessing:** Preprocesses the collected data by removing missing values, scaling, and normalizing to prepare it for machine learning.

- **Machine Learning Model:** Utilizes the Fast Forest Quantile Regression (FFQR) algorithm, a gradient boosting algorithm in ML.NET, to predict engine efficiency based on OBD data.

- **Web Application:** Integrates the machine learning model into a Blazor web application, providing users with real-time access to and analysis of engine performance data through a modern, responsive user interface.

## Results

Our results show that the proposed approach can accurately predict engine efficiency, achieving a Mean Absolute Error (MAE) of 0.012 and an R-squared (R²) value of 0.98.


