using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System.Globalization;

namespace VoltagePrediction
{
    public class BsonDateTimeSerializer : StructSerializerBase<DateTimeOffset>,
                 IRepresentationConfigurable<BsonDateTimeSerializer>
    {
        private BsonType _representation;
        private string StringSerializationFormat = "yyyy-MM-ddTHH:mm:ss.FFFFFFK";

        public BsonDateTimeSerializer() : this(BsonType.DateTime)
        {
        }

        public BsonDateTimeSerializer(BsonType representation)
        {
            switch (representation)
            {
                case BsonType.String:
                case BsonType.DateTime:
                    break;
                default:
                    throw new ArgumentException(string.Format("{0} is not a valid representation for {1}", representation, this.GetType().Name));
            }

            _representation = representation;
        }

        public BsonType Representation => _representation;

        public override DateTimeOffset Deserialize(BsonDeserializationContext context,
                                                   BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;
            long ticks;
            TimeSpan offset;

            BsonType bsonType = bsonReader.GetCurrentBsonType();
            switch (bsonType)
            {
                case BsonType.String:
                    var stringValue = bsonReader.ReadString();
                    return DateTimeOffset.ParseExact
                        (stringValue, StringSerializationFormat, DateTimeFormatInfo.InvariantInfo);

                case BsonType.DateTime:
                    var dateTimeValue = bsonReader.ReadDateTime();
                    return DateTimeOffset.FromUnixTimeMilliseconds(dateTimeValue);

                default:
                    throw CreateCannotDeserializeFromBsonTypeException(bsonType);
            }
        }

        public override void Serialize
           (BsonSerializationContext context, BsonSerializationArgs args, DateTimeOffset value)
        {
            var bsonWriter = context.Writer;

            switch (_representation)
            {
                case BsonType.String:
                    bsonWriter.WriteString(value.ToString
                          (StringSerializationFormat, DateTimeFormatInfo.InvariantInfo));
                    break;

                case BsonType.DateTime:
                    bsonWriter.WriteDateTime(value.ToUnixTimeMilliseconds());
                    break;

                default:
                    var message = string.Format("'{0}' is not a valid DateTimeOffset representation.", _representation);
                    throw new BsonSerializationException(message);
            }
        }

        public BsonDateTimeSerializer WithRepresentation(BsonType representation)
        {
            if (representation == _representation)
            {
                return this;
            }
            return new BsonDateTimeSerializer(representation);
        }

        IBsonSerializer IRepresentationConfigurable.WithRepresentation(BsonType representation)
        {
            return WithRepresentation(representation);
        }

        protected Exception CreateCannotDeserializeFromBsonTypeException(BsonType bsonType)
        {
            var message = string.Format("Cannot deserialize a '{0}' from BsonType '{1}'.",
                BsonUtils.GetFriendlyTypeName(ValueType),
                bsonType);
            return new FormatException(message);
        }
    }
}
