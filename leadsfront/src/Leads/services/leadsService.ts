import { useMutation, useQuery } from '@tanstack/react-query'
import axios from './axiosInstance'
import { Lead } from '../types/Lead'


const fetchLeads = async (status: string): Promise<Lead[]> => {
    const { data } = await axios.get(`/api/lead/${status}`);
    return data;
  };

export const getInviteLeads = () => {
    return useQuery({
        queryKey: ['leadsData'],
        queryFn: () => fetchLeads("invited"),
      })
}

export const getAcceptedLeads = () => {
    return useQuery({
        queryKey: ['leadsData'],
        queryFn: () => fetchLeads("accepted"),
      })
}

const updateStatusAccept = async (id: number): Promise<void> => {
    const { data } = await axios.put(`/api/lead/accept`, {  id  });
    return data;
  };

export const putAcceptLead = () => {
    return useMutation({
        mutationFn: updateStatusAccept
      })
}

const updateStatusDecline = async (id: number): Promise<void> => {
    const { data } = await axios.put(`/api/lead/decline`, { id });
    return data;
  };

export const putDeclineLead = () => {
    return useMutation({
        mutationFn: updateStatusDecline
      })
}