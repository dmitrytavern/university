package com.example.exam

import android.content.Context
import androidx.room.Database as RoomDatabaseDecorator
import androidx.room.Room
import androidx.room.RoomDatabase
import com.example.exam.entities.Employee
import com.example.exam.interfaces.EmployeeDao

@RoomDatabaseDecorator(entities = [(Employee::class)], version = 1, exportSchema = false)
abstract class Database : RoomDatabase() {

    abstract fun employeeDao(): EmployeeDao

    companion object {
        @Volatile
        private var INSTANCE: com.example.exam.Database? = null

        fun getInstance(context: Context): com.example.exam.Database {
            synchronized(this) {
                var instance = INSTANCE

                if (instance == null) {
                    instance = Room.databaseBuilder(
                        context.applicationContext,
                        Database::class.java,
                        "employee_database"
                    ).fallbackToDestructiveMigration()
                        .build()

                    INSTANCE = instance
                }

                return instance
            }
        }
    }
}