class CommandCentre:
    def __init__(self):
        self.runways = []
        self.aircrafts = []

    def add_runway(self, runway):
        self.runways.append(runway)

    def add_aircraft(self, aircraft):
        self.aircrafts.append(aircraft)

    def request_landing(self, aircraft):
        for runway in self.runways:
            if runway.is_available():
                runway.land(aircraft)
                return f"Aircraft {aircraft.identifier} has landed on runway {runway.identifier}."
        return f"No available runways for aircraft {aircraft.identifier}. Please wait."

    def release_runway(self, runway):
        runway.release()
        return f"Runway {runway.identifier} is now available."


class Runway:
    def __init__(self, identifier):
        self.identifier = identifier
        self.occupied = False

    def is_available(self):
        return not self.occupied

    def land(self, aircraft):
        if not self.occupied:
            self.occupied = True
            print(f"Aircraft {aircraft.identifier} is landing on runway {self.identifier}.")

    def release(self):
        self.occupied = False
        print(f"Runway {self.identifier} is now available.")


class Aircraft:
    def __init__(self, identifier, command_centre):
        self.identifier = identifier
        self.command_centre = command_centre

    def request_landing(self):
        return self.command_centre.request_landing(self)

    def land(self):
        print(f"Aircraft {self.identifier} has landed.")


def main():
    command_centre = CommandCentre()

    runway1 = Runway("RW1")
    runway2 = Runway("RW2")

    command_centre.add_runway(runway1)
    command_centre.add_runway(runway2)

    aircraft1 = Aircraft("AC1", command_centre)
    aircraft2 = Aircraft("AC2", command_centre)

    command_centre.add_aircraft(aircraft1)
    command_centre.add_aircraft(aircraft2)

    print(aircraft1.request_landing())
    print(aircraft2.request_landing())

    print(command_centre.release_runway(runway1))

    print(aircraft2.request_landing())

if __name__ == "__main__":
    main()
