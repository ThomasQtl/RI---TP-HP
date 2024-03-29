using System;

public class XXNoiseGenerator : NoiseGenerator {
    XXHash64 hash;

    public XXNoiseGenerator(uint seed) {
        hash = new XXHash64(seed);
    }

    public float Generate(float x, float y, int i) {
        byte[] data = new byte[sizeof(float) * 2 + sizeof(int)];

        Buffer.BlockCopy(BitConverter.GetBytes(x), 0, data, 0, sizeof(float));
        Buffer.BlockCopy(BitConverter.GetBytes(y), 0, data, sizeof(float), sizeof(float));
        Buffer.BlockCopy(BitConverter.GetBytes(i), 0, data, 2*sizeof(float), sizeof(int));

        byte[] hash = this.hash.ComputeHash(data);

        uint hash_number = (uint)BitConverter.ToUInt32(hash, 0);

        return hash_number / (float)uint.MaxValue;
    }
}