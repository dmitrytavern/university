package com.example.exam.interfaces

import androidx.lifecycle.LiveData
import androidx.room.*
import com.example.exam.entities.Employee

@Dao
interface EmployeeDao {
    @Query("SELECT * FROM employees")
    fun getAllEmployees(): LiveData<List<Employee>>

    @Query("SELECT * FROM employees WHERE id = :empId")
    fun findEmployeeById(empId: String): Employee

    @Insert(onConflict = OnConflictStrategy.IGNORE)
    suspend fun addEmployee(employee: Employee)

    @Update
    suspend fun updateEmployeeDetails(employee: Employee)

    @Delete
    suspend fun deleteEmployee(employee: Employee)
}
