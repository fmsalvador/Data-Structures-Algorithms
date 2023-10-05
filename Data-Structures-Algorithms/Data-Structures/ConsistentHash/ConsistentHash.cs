using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace Data_Structures_Algorithms.Data_Structures
{

    //Reference http://www.codeproject.com/Articles/56138/Consistent-hashing
    //and https://github.com/Jaskey/ConsistentHash

    public class ConsistentHash
    {

        public void Test()
        {
            ServiceNode node1 = new ServiceNode("IDC1", "127.0.0.1", 8080);
            ServiceNode node2 = new ServiceNode("IDC1", "127.0.0.1", 8081);
            ServiceNode node3 = new ServiceNode("IDC1", "127.0.0.1", 8082);
            ServiceNode node4 = new ServiceNode("IDC1", "127.0.0.1", 8084);

            List<ServiceNode> nodes = new List<ServiceNode> { node1, node2, node3, node4 };

            var consistentHashRouter = new ConsistentHashRouter<ServiceNode>(nodes, 10);

            String requestIP1 = "192.168.0.1";
            String requestIP2 = "192.168.0.2";
            String requestIP3 = "192.168.0.3";
            String requestIP4 = "192.168.0.4";
            String requestIP5 = "192.168.0.5";

            List<String> requests = new List<string> { requestIP1, requestIP2, requestIP3, requestIP4, requestIP5 };

            GoRoute(consistentHashRouter, requests);

            consistentHashRouter.RemoveNode(node3);
            Console.WriteLine("");
            Console.WriteLine("Remove node with key " + node3.GetKey());
            Console.WriteLine("");


            GoRoute(consistentHashRouter, requests);
        }


        public void GoRoute(ConsistentHashRouter<ServiceNode> consistentHashRouter, List<String> requestIps)
        {
            foreach (var requestIp in requestIps)
            {
                Console.WriteLine(requestIp + " is route to " + consistentHashRouter.RouteNode(requestIp).ToString());
            }
        }

        public class ServiceNode : NodeMap
        {
            private String idc;
            private String ip;
            private int port;

            public ServiceNode(String idc, String ip, int port)
            {
                this.idc = idc;
                this.ip = ip;
                this.port = port;
            }

            public String GetKey()
            {
                return idc + "-" + ip + ":" + port;
            }

            public override String ToString()
            {
                return GetKey();
            }
        }

        public class ConsistentHashRouter<T> where T : NodeMap
        {
            SortedDictionary<BigInteger, VirtualNode<T>> ring = new SortedDictionary<BigInteger, VirtualNode<T>>();

            public ConsistentHashRouter(List<T> pNodes, int vNodeCount)
            {
                if (pNodes != null)
                    foreach (var node in pNodes)
                        AddNode(node, vNodeCount);
            }

            public void AddNode(T pNode, int vNodeCount)
            {
                if (vNodeCount < 0)
                    throw new ArgumentException("illegal virtual node counts :" + vNodeCount);

                int existingReplicas = GetExistingReplicas(pNode);
                for (int i = 0; i < vNodeCount; i++)
                {
                    VirtualNode<T> vNode = new VirtualNode<T>(pNode, i + existingReplicas);
                    ring.Add(vNode.GetKey().GetHashCode(), vNode);
                }
            }

            public void RemoveNode(T pNode)
            {
                var tempList = ring.Keys;
                List<BigInteger> nodeKeysToRemove = new List<BigInteger>();


                foreach(var key in tempList)
                {
                    VirtualNode<T> virtualNode = ring.GetValueOrDefault(key);
                    if (virtualNode.isVirtualNodeOf(pNode))
                    {
                        nodeKeysToRemove.Add(key);
                    }
                }

                foreach(var nodeToRemove in nodeKeysToRemove)
                {
                    ring.Remove(nodeToRemove);
                }
            }

            public int GetExistingReplicas(T pNode)
            {
                int replicas = 0;
                foreach (var vNode in ring.Values)
                {
                    if (vNode.isVirtualNodeOf(pNode))
                    {
                        replicas++;
                    }
                }
                return replicas;
            }

            //With a specified key, route the nearest Node instance in the current hash ring
            public T RouteNode(String objectKey)
            {
                if (ring.Count == 0)
                    return default(T);

                var hashVal = objectKey.GetHashCode();
                var listKeys = ring.Keys.OrderBy(o => o).ToList();
                var tailMap = listKeys.Where(w => w >= hashVal);

                var nodeHashVal = (tailMap != null && tailMap.Count() > 0) ? tailMap.First() : listKeys.First();
                return ring[nodeHashVal].GetPhysicalNode();
            }
        }


        public class VirtualNode<T> where T : NodeMap
        {
            T physicalNode;
            int replicaIndex;

            public VirtualNode(T physicalNode, int replicaIndex)
            {
                this.replicaIndex = replicaIndex;
                this.physicalNode = physicalNode;
            }

            public String GetKey()
            {
                return physicalNode.GetKey() + "-" + replicaIndex;
            }

            public Boolean isVirtualNodeOf(T pNode)
            {
                return physicalNode.GetKey().Equals(pNode.GetKey());
            }

            public T GetPhysicalNode()
            {
                return physicalNode;
            }
        }

        public interface NodeMap
        {
            String GetKey();
        }
    }
}

