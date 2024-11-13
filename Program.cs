 namespace ClassAssessment
    {
        class Smartwatch
        {
            // Private member variables
            private string brand;
            private int batteryLevel;
            private int steps;
            private double heartRate;
            private int sleepHours;
            private bool isTracking;

            // Constructor to initialize the smartwatch
            public Smartwatch(string brand)
            {
                this.brand = brand;
                this.batteryLevel = 100; // Battery starts at full
                this.steps = 0;
                this.heartRate = 70.0; // Default heart rate
                this.sleepHours = 0;
                this.isTracking = false;
            }

            // Private method to save battery
            private void SaveBattery()
            {
                if (batteryLevel < 20)
                {
                    Console.WriteLine("Battery is low. Entering power-saving mode.");
                    isTracking = false;
                }
            }

            // Public method to start tracking fitness metrics
            public void StartTracking()
            {
                if (batteryLevel <= 0)
                {
                    Console.WriteLine("Battery is dead. Please recharge your smartwatch.");
                    return;
                }

                isTracking = true;
                Console.WriteLine("Tracking started.");
            }

            // Public method to stop tracking fitness metrics
            public void StopTracking()
            {
                isTracking = false;
                Console.WriteLine("Tracking stopped.");
            }

            // Public method to simulate a workout
            public void Workout(int durationMinutes)
            {
                if (!isTracking)
                {
                    Console.WriteLine("Please start tracking before starting a workout.");
                    return;
                }

                steps += durationMinutes * 100;      // 100 steps per minute
                heartRate += 0.1 * durationMinutes; // Increase heart rate slightly
                batteryLevel -= durationMinutes / 5; // Decrease battery level

                Console.WriteLine("You worked out for "+ durationMinutes +" minutes.");
                Console.WriteLine("Steps: " +steps+", Heart Rate: " + heartRate +" BPM, Battery: "+batteryLevel+"%");

                SaveBattery();
            }

            // Public method to record sleep
            public void RecordSleep(int hours)
            {
                if (hours < 0 || hours > 12)
                {
                    Console.WriteLine("Invalid sleep duration. Please enter a value between 0 and 12 hours.");
                    return;
                }

                sleepHours += hours;
                batteryLevel -= hours; // Simulate battery drain during sleep tracking

                Console.WriteLine($"You recorded "+hours+" hours of sleep. Total sleep: "+ sleepHours +" hours.");
                SaveBattery();
            }

            // Public method to check smartwatch status
            public void CheckStatus()
            {
                Console.WriteLine($"\n--- Smartwatch Status ---");
                Console.WriteLine("Brand: "+ brand);
                Console.WriteLine("Battery Level: "+ batteryLevel+"%");
                Console.WriteLine("Steps Taken: " + steps);
                Console.WriteLine("Current Heart Rate:" + heartRate +" BPM");
                Console.WriteLine("Total Sleep Hours: "+ sleepHours);
                Console.WriteLine("Tracking Active: "+ isTracking +"\n");
            }

            // Public method to recharge the smartwatch
            public void Recharge()
            {
                batteryLevel = 100;
                Console.WriteLine("Smartwatch fully recharged.");
            }
        }

        // Main Program
        class Program
        {
            static void Main(string[] args)
            {
                // Ask the user for the smartwatch brand
                Console.Write("Enter the brand of your smartwatch: ");
                string brand = Console.ReadLine();

                // Create an instance of the Smartwatch class
                Smartwatch myWatch = new Smartwatch(brand);

                // Interact with the smartwatch
                myWatch.CheckStatus();

                // Start tracking
                Console.Write("Do you want to start tracking? (yes/no): ");
                string startTracking = Console.ReadLine();
                if (startTracking.ToLower() == "yes")
                {
                    myWatch.StartTracking();
                }

                // Log a workout
                Console.Write("Enter workout duration in minutes: ");
                int workoutDuration;
                if (int.TryParse(Console.ReadLine(), out workoutDuration) && workoutDuration > 0)
                {
                    myWatch.Workout(workoutDuration);
                }
                else
                {
                    Console.WriteLine("Invalid workout duration.");
                }

                // Record sleep
                Console.Write("Enter sleep duration in hours: ");
                int sleepDuration;
                if (int.TryParse(Console.ReadLine(), out sleepDuration) && sleepDuration >= 0 && sleepDuration <= 12)
                {
                    myWatch.RecordSleep(sleepDuration);
                }
                else
                {
                    Console.WriteLine("Invalid sleep duration.");
                }

                // Show status
                myWatch.CheckStatus();

                // Stop tracking
                Console.Write("Do you want to stop tracking? (yes/no): ");
                string stopTracking = Console.ReadLine();
                if (stopTracking.ToLower() == "yes")
                {
                    myWatch.StopTracking();
                }

                // Recharge the smartwatch
                Console.Write("Do you want to recharge the smartwatch? (yes/no): ");
                string recharge = Console.ReadLine();
                if (recharge.ToLower() == "yes")
                {
                    myWatch.Recharge();
                }

                // Final status check
                myWatch.CheckStatus();
            }
        }
    }


