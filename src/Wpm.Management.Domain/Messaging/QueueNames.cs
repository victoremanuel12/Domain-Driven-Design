namespace Wpm.Management.Domain
{
    public static class QueueNames
    {
        public static class Pet
        {
            // This queue is used to trigger the creation of a pet when a new pet is created in the system.(desconsiderar o nome da fila, é apenas um exemplo)
            public const string Created = "first-queue";
            public const string Updated = "pet-updated";
        }

        public static class Breed
        {
            public const string Created = "breed-created";
        }

    }
}
