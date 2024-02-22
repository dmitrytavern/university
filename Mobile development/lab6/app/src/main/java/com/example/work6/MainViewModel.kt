package com.example.work6

import androidx.lifecycle.LiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.work6.database.Employee
import com.example.work6.database.EmployeeDao
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch
import javax.inject.Inject

@HiltViewModel
class MainViewModel @Inject constructor(private val dao: EmployeeDao) :
    ViewModel() {

    fun getAllEmployees(): LiveData<List<Employee>> {
        return dao.getAllEmployees()
    }

    fun addEmployee(employee: Employee) {
        viewModelScope.launch {
            dao.addEmployee(employee)
        }
    }
}